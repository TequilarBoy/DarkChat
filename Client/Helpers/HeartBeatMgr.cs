using Client.Unit;
using DarkClient.Unit;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client.Helpers
{
    public static class HeartBeatMgr
    {
        private static int _pingInterval = 10 * 1000;       // Current heartbeat interval
        private static int _pingMaxInterval = 30 * 1000;    // Maximum heartbeat interval
        private static int _pingMinInterval = 10 * 1000;    // Minimum heartbeat interval
        private static int _pongThreshold = 5 * 1000;       // Pong responding time threshold
        private static int _pongMaxThreshold = 30 * 1000;   // Pong deadline threashold(means disconnected)
        private static DateTime _lastSeen;                  // Timestamp of the last pong received
        private static Timer _pingTimer;                    // Timer to send ping package to server
        private static Timer _pongTimer;                    // Check if pong is timeout(server disconnects)

        private static readonly object _lastSeenLock = new object();

        private static bool _connected = true;

        public static void StartHeartbeat(Socket sock)
        {
            _connected = true;
            _lastSeen = DateTime.UtcNow;
            // # BUG: _pingTimer is null
            _pingTimer = new Timer(SendPing, sock, 0, _pingInterval);
            _pongTimer = new Timer(CheckPongTimeout, null, 0, _pongMaxThreshold);
        }

        public static void StopHeartbeat()
        {
            if (_connected)
            {
                _connected = false;
                _pingTimer.Dispose();
                _pongTimer.Dispose();
            }
        }

        private static void SendPing(object state)
        {
            if (_connected)
            {
                // Send heartbeat
                Package.SendCmdPkg((Socket)state, new DarkMsg()
                {
                    code = CommandCode.COMMAND_PING,
                    msg = "",
                    lastSeen = DateTime.UtcNow
                });
                // Adjust heartbeat interval
                AdjustHeartbeatInterval();
            }
            else
            {
                // Reconnect
                _connected = HandlePongTimeout();
            }
        }

        private static void CheckPongTimeout(object state)
        {
            lock (_lastSeenLock)
            {
                if ((DateTime.UtcNow - _lastSeen).TotalMilliseconds >= _pongMaxThreshold)
                {
                    _connected = false;
                }
            }
        }

        private static bool HandlePongTimeout()
        {
            // Timeout, try to reconnect
            _connected = false;
            return _connected;
        }

        public static void ReceivePong(DateTime pongReceive)
        {
            // Update pong(lastseen)
            lock (_lastSeenLock)
            {
                _lastSeen = pongReceive;
            }
        }

        private static void AdjustHeartbeatInterval()
        {
            lock (_lastSeenLock)
            {
                // Ensure that the interval between heartbeat packets
                // is within the range of _pingThreshold±5
                if ((DateTime.UtcNow - _lastSeen).TotalMilliseconds > _pongThreshold)
                {
                    _pingInterval = Math.Min(_pingInterval + 5000, _pingMaxInterval);
                }
                else
                {
                    _pingInterval = Math.Max(_pingInterval - 5000, _pingMinInterval);
                }
            }
            // Update heartbeat interval
            _pingTimer.Change(_pingInterval, _pingInterval);
        }
    }
}
