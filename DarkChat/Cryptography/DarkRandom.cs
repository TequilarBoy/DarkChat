using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DarkChat.Cryptography
{
    public static class DarkRandom
    {
        public static string RandomString(int len)
        {
            string hash = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder sb = new StringBuilder();

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] result = new byte[len];
                rng.GetBytes(result);

                for (int i = 0; i < len; ++i)
                {
                    sb.Append(hash[result[i] % hash.Length]);
                }
                return sb.ToString();
            }
        }
    }
}
