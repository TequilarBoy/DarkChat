using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Client.Cryptography
{
    public static class SHA
    {
        public static byte[] Sha256(byte[] bytesContent)
        {
            try
            {
                using (SHA256 sha = SHA256.Create())
                {
                    return sha.ComputeHash(bytesContent);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return null;
            }
        }
    }
}
