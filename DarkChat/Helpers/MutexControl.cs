using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DarkChat.Helpers
{
    public static class MutexControl
    {
        public static Mutex mutexObject;

        public static bool CreateMutex()
        {
            mutexObject = new Mutex(false, Settings.mutexName, out bool createdNew);
            return createdNew;
        }

        public static void CloseMutex()
        {
            if (null != mutexObject)
            {
                mutexObject.Close();
                mutexObject = null;
            }
        }
    }
}
