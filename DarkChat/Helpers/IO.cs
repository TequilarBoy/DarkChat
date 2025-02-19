using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkChat.Helpers
{
    public static class IO
    {
        public static string ReadTextFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                return string.Empty;
            }

            try
            {
                StringBuilder sb = new StringBuilder();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while (null != (line = reader.ReadLine()))
                    {
                        sb.AppendLine(line);
                    }
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static bool WriteTextFile(string filePath, string content, int bufferSize = 4096)
        {
            if (string.IsNullOrEmpty(filePath) || 
                string.IsNullOrEmpty(content))
            {
                return false;
            }

            try
            {
                if (!File.Exists(filePath))
                {
                    using (File.Create(filePath)) { }
                }

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    int contentLength = content.Length;
                    int offset = 0;

                    while (offset < contentLength)
                    {
                        int lengthToWrite = Math.Min(bufferSize, contentLength - offset);
                        sw.Write(content.Substring(offset, lengthToWrite));
                        offset += lengthToWrite;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static byte[] ReadBinaryFile(string filePath, int bufferSize = 4096)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                return null;
            }
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[bufferSize];
                    using (MemoryStream ms = new MemoryStream())
                    {
                        int bytesRead = 0;
                        while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, bytesRead);
                        }

                        return ms.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static int WriteBinaryFile(string filePath, byte[] data, int bufferSize = 4096)
        {
            if (string.IsNullOrEmpty(filePath) || null == data)
            {
                return -1;
            }

            try
            {
                if (!File.Exists(filePath))
                {
                    using (File.Create(filePath)) { }
                }

                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    int offset = 0;
                    while (offset < data.Length)
                    {
                        int bytesToWrite = Math.Min(bufferSize, data.Length - offset);
                        fs.Write(data, 0, bytesToWrite);
                        offset += bytesToWrite;
                    }

                    return offset;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
