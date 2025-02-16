/*
    This file mostly for AES256-CBC encryption
*/
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Client.Cryptography
{
    public static class AES256
    {
        /// <summary>
        /// Generate AES key(32bytes)
        /// </summary>
        /// <param name="password">Password string</param>
        /// <returns>Bytes array of AES256 keys(32 bytes)</returns>
        public static byte[] KeyGen(string password)
        {
            byte[] result = new byte[16 + 32];

            using (Rfc2898DeriveBytes gen = new Rfc2898DeriveBytes(password, 16, 10000))
            {
                Buffer.BlockCopy(gen.Salt, 0, result, 0, gen.Salt.Length);
                Buffer.BlockCopy(gen.GetBytes(32), 0, result, gen.Salt.Length, 32);
            }

            return result;
        }

        /// <summary>
        /// Get key(32bytes) with specific password and salt
        /// </summary>
        /// <param name="password">Password string</param>
        /// <param name="salt">Salt byte array</param>
        /// <returns>32 bytes key array</returns>
        public static byte[] KeyGenWithSalt(string password, byte[] salt)
        {
            byte[] key = null;

            using (Rfc2898DeriveBytes gen = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                key = new byte[32];
                Buffer.BlockCopy(gen.GetBytes(32), 0, key, 0, key.Length);
            }

            return key;
        }

        /// <summary>
        /// AES256 CBC encryption algorithm
        /// </summary>
        /// <param name="plain">Plain text in bytes</param>
        /// <param name="password">Password string</param>
        /// <returns>The result of encryption in Base64</returns>
        public static string AES256EncCBC(byte[] plain, string password)
        {
            // Result format: | IV(16 bytes) | Salt(16 bytes) | Encrypted(n bytes) |
            byte[] bytesResult = KeyGen(password);

            byte[] bytesSalt = new byte[16];
            byte[] bytesKey = new byte[32];

            Buffer.BlockCopy(bytesResult, 0, bytesSalt, 0, 16);
            Buffer.BlockCopy(bytesResult, 16, bytesKey, 0, 32);

            using (MemoryStream ms = new MemoryStream())
            {
                using (AesCryptoServiceProvider aes256 = new AesCryptoServiceProvider())
                {
                    aes256.KeySize = 256;
                    aes256.BlockSize = 128;
                    aes256.GenerateIV();
                    aes256.Padding = PaddingMode.PKCS7;
                    aes256.Mode = CipherMode.CBC;
                    aes256.Key = bytesKey;
                    bytesKey = null;

                    using (CryptoStream cs = new CryptoStream(ms, aes256.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        ms.Write(aes256.IV, 0, aes256.IV.Length);
                        ms.Write(bytesSalt, 0, bytesSalt.Length);
                        cs.Write(plain, 0, plain.Length);
                    }
                }
                return Convert.ToBase64String(ms.ToArray());
            }

        }

        /// <summary>
        /// Decrypt AES256-CBC
        /// </summary>
        /// <param name="encrypted">Encrypted content with base64 format</param>
        /// <param name="password">Password string</param>
        /// <returns></returns>
        public static string AES256DecCBC(byte[] encrypted, string password)
        {
            using (MemoryStream ms = new MemoryStream(encrypted))
            {
                using (AesCryptoServiceProvider aes256 = new AesCryptoServiceProvider())
                {
                    byte[] salt = new byte[16];
                    byte[] iv = new byte[16];
                    // Read salt and IV
                    ms.Read(iv, 0, iv.Length);
                    ms.Read(salt, 0, salt.Length);

                    aes256.KeySize = 256;
                    aes256.BlockSize = 128;
                    aes256.IV = iv;
                    aes256.Padding = PaddingMode.PKCS7;
                    aes256.Mode = CipherMode.CBC;
                    aes256.Key = KeyGenWithSalt(password, salt);

                    using (CryptoStream cs = new CryptoStream(ms, aes256.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        // Exclude the length of iv and salt, the rest is encrypted content
                        byte[] temp = new byte[ms.Length - 32];
                        byte[] result = new byte[cs.Read(temp, 0, temp.Length)];
                        Buffer.BlockCopy(temp, 0, result, 0, result.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }
    }
}
