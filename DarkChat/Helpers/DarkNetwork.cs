using DarkClient.Unit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DarkChat.Unit;

namespace DarkChat.Helpers
{
    public class DarkNetwork
    {
        private Thread thrdListen = null;
        private Socket sockListen = null;

        // All clients info in it
        private ClientsHive hive = null;

        // Heartbeat checking object 
        private HeartBeatMgr _heartBeat = null;

        // Events notify UI changes
        public event Action<Socket, string> OnDrawMsg;
        public event Action<Socket> OnClientOffline;
        public event Action<Socket, DarkMsg> OnClientOnline;

        public DarkNetwork(out ClientsHive theHive, HeartBeatMgr heartBeat)
        {
            // Save heartbeat object 
            _heartBeat = heartBeat;
            // Initialize clients hive
            hive = ClientsHive.GetHive;
            theHive = hive;
        }

        public bool StartServer(string ip, int port)
        {
            try
            {
                sockListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPAddress address = (ip.Length > 0) ? IPAddress.Parse(ip) : IPAddress.Any;
                IPEndPoint endPoint = new IPEndPoint(address, port);

                sockListen.Bind(endPoint);

                sockListen.Listen(999999);

                Logger.Log($"Server is starting, listen on: {address}:{port}");

                // Start the thread of handling clients
                thrdListen = new Thread(ListenHandler);
                thrdListen.IsBackground = true;
                thrdListen.Start();

            }
            catch (Exception ex)
            {

            }

            return true;
        }

        private void UpdateLastseenByPong(Socket sock, DateTime dateTime)
        {
            lock (hive.lockerClients)
            {
                hive.dictClients[sock].lastSeen = dateTime;
            }
        }

        private void ClientHandler(object obj)
        {
            Socket sockClient = obj as Socket;

            int recv = 0;
            long len = 0;
            byte[] byteslen = new byte[8];
            byte[] buffer = null;
            bool running = true;

            while (running)
            {
                try
                {
                    // The length of content
                    recv = sockClient.Receive(byteslen, byteslen.Length, SocketFlags.None);
                    len = BitConverter.ToInt64(byteslen, 0);
                    // Buffer to receive content
                    buffer = new byte[len];

                    // Receive package
                    if (DarkRecv(sockClient, buffer, (int)len) < 0)
                    {
                        throw new SocketException();
                    }
                    string strPkg = Encoding.UTF8.GetString(buffer);
                    DarkMsg darkMsg = JsonConvert.DeserializeObject<DarkMsg>(strPkg);

                    switch (darkMsg.code)
                    {
                        case CommandCode.COMMAND_JOIN:
                            {
                                ClientOnline(sockClient, darkMsg);
                                break;
                            }
                        case CommandCode.COMMAND_MSG:
                            {
                                DrawMsg(sockClient, darkMsg.msg);
                                break;
                            }
                        case CommandCode.COMMAND_PING:
                            {
                                // Update the lastseen of the client
                                UpdateLastseenByPong(sockClient, darkMsg.lastSeen);
                                // Replay pong to client
                                Package.SendCmdPkg(sockClient, new DarkMsg()
                                {
                                    code = CommandCode.TOKEN_PONG,
                                    lastSeen = DateTime.UtcNow,
                                    msg = ""
                                });
                                break;
                            }
                    }
                }
                catch (SocketException ex)
                {
                    running = false;
                    ClientOffline(sockClient);
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.Message);
                }
            }
        }

        public void DrawMsg(Socket sock, string msg)
        {
            OnDrawMsg?.Invoke(sock, msg);
        }

        public void ClientOffline(Socket sockClient)
        {
            OnClientOffline?.Invoke(sockClient);
        }

        public void ClientOnline(Socket sockClient, DarkMsg darkMsg)
        {
            OnClientOnline?.Invoke(sockClient, darkMsg);
        }

        private void ListenHandler()
        {
            // Start heartbeat checking thread
            _heartBeat.ScanTimeoutClient(-1);

            while (true)
            {
                Socket sockClient = null;

                try
                {
                    // Blocking, wait for the connection of clients
                    sockClient = sockListen.Accept();

                    IPEndPoint pt = (IPEndPoint)sockClient.RemoteEndPoint;

                    // Create thread to serve clients
                    Thread thrdClient = new Thread(new ParameterizedThreadStart(ClientHandler));
                    thrdClient.IsBackground = true;
                    thrdClient.Start(sockClient);
                }
                catch (Exception ex)
                {

                }
            }
        }


        public static int DarkRecv(Socket sock, byte[] buffer, int total)
        {
            if (null == sock || !sock.Connected)
            {
                return -1;
            }
            if (null == buffer || 0 == buffer.Length)
            {
                return -1;
            }

            int bytesReceived = 0;
            int blockSize = 0;
            int totalRecv = 0;

            try
            {
                while (total > 0)
                {
                    blockSize = Math.Min(1000000, total);
                    bytesReceived = sock.Receive(buffer, totalRecv, blockSize, SocketFlags.None);
                    if (0 == bytesReceived)
                    {
                        break;
                    }
                    totalRecv += bytesReceived;
                    total -= bytesReceived;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }

            return totalRecv;
        }

        public static int DarkSend(Socket sock, byte[] content)
        {
            if (null == sock || !sock.Connected)
            {
                return -1;
            }

            if (null == content || 0 == content.Length)
            {
                return -1;
            }

            int totalSend = 0;
            int contentLen = content.Length;
            int blockSize = 0;
            byte[] clip = new byte[contentLen];

            try
            {
                while (totalSend < contentLen)
                {
                    blockSize = Math.Min(1000000, contentLen - totalSend);
                    Array.Copy(content, totalSend, clip, 0, blockSize);
                    int curSend = sock.Send(clip, blockSize, SocketFlags.None);
                    if (0 == curSend)
                    {
                        break;
                    }
                    totalSend += curSend;
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"{ex.Message}");
            }

            return totalSend;
        }
    }
}
