using Client.Cryptography;
using DarkChat.Cryptography;
using DarkChat.Unit;
using DarkClient.Unit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test;

namespace DarkChat.Helpers
{
    public static class Package
    {
        public static RsaUtils rsa = DarkClient.Unit.ClientsHive.GetHive.rsa;

        //rsa = new RsaUtils(Settings.privKey, Settings.pubKey);
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

        public static DarkMsg BuildMsgPkg(CommandCode code, string msg)
        {
            // Generate random string for AES256 symmetric key
            try
            {
                if (string.IsNullOrEmpty(msg))
                {
                    return null;
                }
                // Generate AES key
                string aes256Key = DarkRandom.RandomString(32);
                // Encrypt AES key 
                string encAes256Key = rsa.RsaEncrypt(aes256Key, RSAEncryptionPadding.Pkcs1);
                // Encrypt message
                string encryptedMsg = AES256.AES256EncCBC(Encoding.UTF8.GetBytes(msg), aes256Key);
                // Generate digital signature
                byte[] sha256 = SHA.Sha256(Encoding.UTF8.GetBytes(encryptedMsg));
                string ds = rsa.RsaEncrypt(Convert.ToBase64String(sha256), RSAEncryptionPadding.Pkcs1);

                MsgPkg pkg = new MsgPkg()
                {
                    EncAesKey = encAes256Key,
                    DigitialSignature = ds,
                    EncMsg = encAes256Key
                };

                string pkgMsg = JsonConvert.SerializeObject(pkg);

                return new DarkMsg()
                {
                    code = code,
                    msg = pkgMsg
                };
            }
            catch (Exception ex) 
            {
                Debug.WriteLine($"{ex.Message}");    
            }

            return null;
        }

    }

    public class MsgPkg
    {
        public string EncAesKey { get; set; }
        public string DigitialSignature { get; set; }
        public string EncMsg { get; set; }
    }
}
