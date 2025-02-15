using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkChat.Helpers
{
    public static class Logger
    {
        public delegate void LogEventHandler(string msg);

        public static event LogEventHandler LogEvent;

        public static void Log(string msg)
        {
            LogEvent?.Invoke(msg);
        }

        public static void SubLogEvent(LogEventHandler handler)
        {
            LogEvent += handler;
        }

        public static void UnsubLogEvent(LogEventHandler handler)
        {
            LogEvent -= handler;
        }
    }
}
