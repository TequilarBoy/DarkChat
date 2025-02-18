using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DarkClient.Unit;

namespace DarkChat.Helpers
{
    public class HeartBeatMgr
    {
        private const int defaultInterval = 40 * 1000;
        private Timer _pongTimer = null;
        private int _pongInterval = defaultInterval;
        private bool _connected = false;

        private object _pongLock = new object();

        // Event that remove the client on list
        public event Action<Socket> OnHeartbeatClientOffline;

        public bool ScanTimeoutClient(int pongInterval)
        {
            try
            {
                lock (_pongLock)
                {
                    if (!_connected)
                    {
                        _pongInterval = (pongInterval > 0) ? pongInterval : defaultInterval;
                        _connected = true;
                        _pongTimer = new Timer(CheckOnlineClients, ClientsHive.GetHive, 0, _pongInterval);
                    }
                }
                
                return true;
            }
            catch (Exception ex) 
            {
                Debug.WriteLine($"{ex.Message}");
                return false;
            }
        }

        public void HeartbeatClientOffline(Socket sockClient)
        {
            OnHeartbeatClientOffline?.Invoke(sockClient);
        }

        public void StopPong()
        {
            try
            {
                lock (_pongLock)
                {
                    if (_connected)
                    {
                        _pongInterval = defaultInterval;
                        _pongTimer.Dispose();
                        _pongTimer = null;
                        _connected = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
            }
        }

        public void CheckOnlineClients(object state)
        {
            lock (_pongLock)
            {
                if (_connected)
                {
                    ClientsHive hive = (ClientsHive)state;
                    List<Socket> lstOfflineClients = new List<Socket>();

                    lock (hive.lockerClients)
                    {
                        foreach (var client in hive.dictClients)
                        {
                           if ((DateTime.UtcNow - client.Value.lastSeen).TotalMilliseconds > _pongInterval)
                            {
                                // Oops, timeout, the client may dead
                                lstOfflineClients.Add(client.Key);
                            }
                        }

                        foreach (var sock in lstOfflineClients)
                        {
                            // Remove the client from the list 
                            hive.dictClients.Remove(sock);
                            HeartbeatClientOffline(sock);
                        }
                    }

                    lock (hive.lockerHandlers)
                    {
                        foreach (var sock in lstOfflineClients)
                        {
                            // Remove the client from the list 
                            hive.dictHandlers.Remove(sock.RemoteEndPoint.ToString());
                        }
                    }
                }
            }
        }
    }
}
