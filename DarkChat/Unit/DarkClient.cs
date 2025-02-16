using DarkChat.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DarkClient.Unit
{
    public enum Sex 
    { 
        FEMALE,
        MALE
    }
    public class DarkMsg
    {
        public CommandCode code { get; set; }
        public DateTime lastSeen { get; set; }
        public string msg { get; set; }
    }

    public class ClientInfo
    {
        public string nickName { get; set; }
        public Sex gender { get; set; }
        public string area { get; set; }
        public string note { get; set; }
        public DateTime lastSeen { get; set; }
    }

    /// <summary>
    /// All clients are in this class 
    /// </summary>
    public class ClientsHive
    {
        private static ClientsHive _hive;
        public static ClientsHive GetHive
        {
            get
            {
                if (_hive == null)
                {
                    _hive = new ClientsHive();
                }
                return _hive;
            }
        }

        public Dictionary<string, Thread> dictHandlers { get; private set; } = new Dictionary<string, Thread>();

        public Dictionary<Socket, ClientInfo> dictClients { get; private set; } = new Dictionary<Socket, ClientInfo>();

        public object lockerClients { get; private set; } = new object();

        public object lockerHandlers { get; private set; } = new object();

        // Make it uninstanceable
        private ClientsHive() { }
    }
    
}
