using DarkClient.Unit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DarkChat.Helpers
{
    public static class Package
    {
        public static bool SendCmdPkg(Socket sock, DarkMsg darkMsg)
        {
            int result = -1;
            try
            {
                string jPkg = JsonConvert.SerializeObject(darkMsg);
                if (jPkg.Length > 0)
                {
                    byte[] bytesPkg = Encoding.UTF8.GetBytes(jPkg);
                    // Package size
                    long size = bytesPkg.LongLength;
                    byte[] bytesSize = BitConverter.GetBytes(size);
                    sock.Send(bytesSize);
                    // Send package
                    result = DarkNetwork.DarkSend(sock, bytesPkg);
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"{ex.Message}");
            }

            return result > 0;
        }
    }
}
