using Client.Helpers;
using DarkChat.Helpers;
using DarkClient.Unit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Unit
{
    public static class Package
    {
        public static bool RecvCmdPkg(Socket sock, out DarkMsg darkMsg)
        {
            darkMsg = null;

            try
            {
                // Receive the length of package
                long size = 0;
                byte[] bytesSize = new byte[8];
                sock.Receive(bytesSize);
                size = BitConverter.ToInt64(bytesSize, 0);
                if (size > 0)
                {
                    // Receive package
                    byte[] bytesPkg = new byte[size];

                    if (DarkNetwork.DarkRecv(sock, bytesPkg, (int)size) > 0)
                    {
                        string strPkg = Encoding.UTF8.GetString(bytesPkg);
                        darkMsg = JsonConvert.DeserializeObject<DarkMsg>(strPkg);
                        return true;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"{ex.Message}");
            }
            return false;
        }
        public static bool SendCmdPkg(Socket sock, DarkMsg darkMsg)
        {
            int result = -1;
            try
            {
                string jPkg = JsonConvert.SerializeObject(darkMsg);
                if (jPkg.Length > 0)
                {
                    byte[] bytesPkg = Encoding.UTF8.GetBytes(jPkg);
                    // Send the size of package
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
