using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client.Helpers
{
    public static class Logger
    {
        public delegate void LogEventHandler(string msg);

        public static event LogEventHandler LogEvent;

        public static void Log(string msg)
        {
            LogEvent?.Invoke(msg);
        }
        
        public static void SubLogger(LogEventHandler handler)
        {
            LogEvent += handler;
        }

        public static void UnsubLogger(LogEventHandler handler)
        {
            LogEvent -= handler;
        }
    }
}
