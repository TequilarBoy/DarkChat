using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkChat.Helpers
{
    public static class TimeDate
    {
        public static string UTCTime()
        {
            DateTime utcNow = DateTime.UtcNow;
            return utcNow.ToString("[yyyy-MM-dd HH:mm:ss]");
        }
    }
}
