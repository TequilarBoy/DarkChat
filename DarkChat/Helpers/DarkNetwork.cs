using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DarkChat.Helpers
{
    public class DarkNetwork
    {
        public static int DarkRecv(Socket sock, byte[] buffer, int total)
        {
            if (null == sock || !sock.Connected)
            {
                return -1;
            }
            if (null == buffer || 0 == buffer.Length)
            {
                return -1;
            }

            int bytesReceived = 0;
            int blockSize = 0;
            int totalRecv = 0;

            try
            {
                while (total > 0)
                {
                    blockSize = Math.Min(1000000, total);
                    bytesReceived = sock.Receive(buffer, totalRecv, blockSize, SocketFlags.None);
                    if (0 == bytesReceived)
                    {
                        break;
                    }
                    totalRecv += bytesReceived;
                    total -= bytesReceived;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }

            return totalRecv;
        }

        public static int DarkSend(Socket sock, byte[] content)
        {
            if (null == sock || !sock.Connected)
            {
                return -1;
            }

            if (null == content || 0 == content.Length)
            {
                return -1;
            }

            int totalSend = 0;
            int contentLen = content.Length;
            int blockSize = 0;
            byte[] clip = new byte[contentLen];

            try
            {
                while (totalSend < contentLen)
                {
                    blockSize = Math.Min(1000000, contentLen - totalSend);
                    Array.Copy(content, totalSend, clip, 0, blockSize);
                    int curSend = sock.Send(clip, blockSize, SocketFlags.None);
                    if (0 == curSend)
                    {
                        break;
                    }
                    totalSend += curSend;
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"{ex.Message}");
            }

            return totalSend;
        }
    }
}
