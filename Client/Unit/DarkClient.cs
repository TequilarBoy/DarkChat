using Client.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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
        public string msg { get; set; }
    }
    public class ClientInfo
    {
        public string nickName { get; set; }
        public Sex gender { get; set; }
        public string area { get; set; }
        public string note { get; set; }
    }
}
