using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Pkcs;
using System.Runtime.InteropServices;

namespace Test
{
    public class RsaUtils
    {
        public RSA privateRsa;
        public RSA publicRsa;
        public Encoding DataEncoding;

        public bool Init(Encoding encoding, string publicKey, 
            string privateKey = null, int keySize = 2048)
        {
            if (string.IsNullOrEmpty(privateKey) && string.IsNullOrEmpty(publicKey))
            {
                return false;
            }

            if (!string.IsNullOrEmpty(privateKey))
            {
                privateRsa = RSA.Create();
                privateRsa.KeySize = keySize;
                var priRsap = CreateRsapFromPrivateKey(privateKey);
                privateRsa.ImportParameters(priRsap);

                if (string.IsNullOrEmpty(publicKey))
                {
                    publicRsa = RSA.Create();
                    publicRsa.KeySize = keySize;
                    var pubRasp = new RSAParameters
                    {
                        Modulus = priRsap.Modulus,
                        Exponent = priRsap.Exponent
                    };
                    publicRsa.ImportParameters(pubRasp);
                }
            }

            if (!string.IsNullOrEmpty(publicKey))
            {
                publicRsa = RSA.Create();
                publicRsa.KeySize = keySize;
                publicRsa.ImportParameters(CreateRsapFromPublicKey(publicKey));
            }

            DataEncoding = encoding ?? Encoding.UTF8;
            return true;
        }

        public RSAParameters CreateRsapFromPrivateKey(string privateKey)
        {
            PemReader pr = new PemReader(new StringReader(privateKey));
            var rsap = new RSAParameters();

            if (!(pr.ReadObject() is AsymmetricCipherKeyPair asymmetricCipherKeyPair))
            {
                return rsap;
            }
            RsaPrivateCrtKeyParameters rsaPrivateCrtKeyParams = (RsaPrivateCrtKeyParameters)
                PrivateKeyFactory.CreateKey(PrivateKeyInfoFactory.CreatePrivateKeyInfo(asymmetricCipherKeyPair.Private));

            rsap.Modulus = rsaPrivateCrtKeyParams.Modulus.ToByteArrayUnsigned();
            rsap.Exponent = rsaPrivateCrtKeyParams.PublicExponent.ToByteArrayUnsigned();
            rsap.P = rsaPrivateCrtKeyParams.P.ToByteArrayUnsigned();
            rsap.Q = rsaPrivateCrtKeyParams.Q.ToByteArrayUnsigned();
            rsap.DP = rsaPrivateCrtKeyParams.DP.ToByteArrayUnsigned();
            rsap.DQ = rsaPrivateCrtKeyParams.DQ.ToByteArrayUnsigned();
            rsap.InverseQ = rsaPrivateCrtKeyParams.QInv.ToByteArrayUnsigned();
            rsap.D = rsaPrivateCrtKeyParams.Exponent.ToByteArrayUnsigned();

            return rsap;
        }

        public RSAParameters CreateRsapFromPublicKey(string publicKey)
        {
            PemReader pr = new PemReader(new StringReader(publicKey));
            var obj = pr.ReadObject();

            RSAParameters rsap = new RSAParameters();

            if (!(obj is RsaKeyParameters rsaKey))
            {
                return rsap;
            }

            rsap.Modulus = rsaKey.Modulus.ToByteArrayUnsigned();
            rsap.Exponent = rsaKey.Exponent.ToByteArrayUnsigned();

            return rsap;
        }

        public string Encrypt(string data, RSAEncryptionPadding padding)
        {
            if (null == publicRsa)
            {
                throw new ArgumentException("Public key can not null");
            }
            byte[] dataBytes = DataEncoding.GetBytes(data);
            var resBytes = publicRsa.Encrypt(dataBytes, padding);

            return Convert.ToBase64String(resBytes);
        }

        public string Decrypt(string data_base64, RSAEncryptionPadding padding)
        {
            if (privateRsa == null)
            {
                throw new ArgumentException("Private key can not null");
            }
            byte[] dataBytes = Convert.FromBase64String(data_base64);
            var resBytes = privateRsa.Decrypt(dataBytes, padding);

            return DataEncoding.GetString(resBytes);
        }

        public string RsaEncrypt(string data, RSAEncryptionPadding padding)
        {
            if (string.IsNullOrEmpty(data) || null == publicRsa)
            {
                return string.Empty;
            }

            try
            {
                byte[] inputBytes = DataEncoding.GetBytes(data);

                int bufferSize = (publicRsa.KeySize / 8) - 11;

                byte[] buffer = new byte[bufferSize];

                using (MemoryStream inputStream = new MemoryStream(inputBytes), outputStream = new MemoryStream())
                {
                    while (true)
                    {
                        int readSize = inputStream.Read(buffer, 0, bufferSize);
                        if (readSize <= 0)
                        {
                            break;
                        }
                        byte[] temp = new byte[readSize];
                        Buffer.BlockCopy(buffer, 0, temp, 0, readSize);

                        byte[] bytesEnc = publicRsa.Encrypt(temp, padding);

                        outputStream.Write(bytesEnc, 0, bytesEnc.Length);
                    }

                    return Convert.ToBase64String(outputStream.ToArray());
                }
            }
            catch (Exception ex)
            {
                
            }

            return string.Empty;
        }

        public string RsaDecrypt(string data, RSAEncryptionPadding padding)
        {
            if (string.IsNullOrEmpty(data) || null == padding)
            {
                return string.Empty;
            }

            byte[] bytesData = Convert.FromBase64String(data);

            int bufferSize = privateRsa.KeySize / 8;

            byte[] buffer = new byte[bufferSize];
            
            using (MemoryStream inputStream = new MemoryStream(bytesData), outputStream = new MemoryStream())
            {
                while (true)
                {
                    int readSize = inputStream.Read(buffer, 0, bufferSize);
                    if (readSize <= 0)
                    {
                        break;
                    }

                    byte[] temp = new byte[readSize];
                    Buffer.BlockCopy(buffer, 0, temp, 0, readSize);
 
                    byte[] raw = privateRsa.Decrypt(temp, padding);
                    outputStream.Write(raw, 0, raw.Length);
                }

                return Encoding.UTF8.GetString(outputStream.ToArray());
            }
        }

        /// <summary>
        /// Generate Pkcs#1 format RSA key pairs
        /// </summary>
        /// <param name="keySize">RSA key size</param>
        /// <param name="format">With format or not</param>
        /// <returns>RSA keys list, first one is private key, second is public key</returns>
        public List<string> Pkcs1Key(int keySize, bool format)
        {
            List<string> res = new List<string>();

            try
            {
                IAsymmetricCipherKeyPairGenerator keyGen = GeneratorUtilities.GetKeyPairGenerator("RSA");
                keyGen.Init(new KeyGenerationParameters(new SecureRandom(), keySize));
                var keyPair = keyGen.GenerateKeyPair();

                using (StringWriter sw = new StringWriter())
                {
                    PemWriter pwrt = new PemWriter(sw);
                    pwrt.WriteObject(keyPair.Private);
                    pwrt.Writer.Close();

                    var privateKey = sw.ToString();

                    if (!format)
                    {
                        privateKey = privateKey.Replace("-----BEGIN RSA PRIVATE KEY-----", "").Replace("-----END RSA PRIVATE KEY-----", "").Replace(Environment.NewLine, ""); ;
                    }
                    res.Add(privateKey);
                }

                using (StringWriter swpub = new StringWriter())
                {
                    PemWriter pwrtpub = new PemWriter(swpub);
                    pwrtpub.WriteObject(keyPair.Public);
                    pwrtpub.Writer.Close();
                    string publicKey = swpub.ToString();
                    if (!format)
                    {
                        publicKey = publicKey.Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", "").Replace(Environment.NewLine, "");
                    }
                    res.Add(publicKey);
                }
            }
            catch (Exception ex)
            {

            }

            return res;
        }

        /// <summary>
        /// Generate Pkcs#8 type RSA key pair
        /// </summary>
        /// <param name="keySize">RSA key size</param>
        /// <param name="format">With format or not</param>
        /// <returns>RSA keys list, first one is private key, second is public key</returns>
        public List<string> Pkcs8Key(int keySize, bool format)
        {
            List<string> res = new List<string>();

            try
            {
                IAsymmetricCipherKeyPairGenerator gen = GeneratorUtilities.GetKeyPairGenerator("RSA");
                gen.Init(new KeyGenerationParameters(new SecureRandom(), keySize));
                var keyPair = gen.GenerateKeyPair();

                StringWriter swpri = new StringWriter();
                PemWriter pwri = new PemWriter(swpri);

                Pkcs8Generator pkcs8 = new Pkcs8Generator(keyPair.Private);
                pwri.WriteObject(pkcs8);
                pwri.Writer.Close();

                string privateKey = swpri.ToString();

                if (!format)
                {
                    privateKey = privateKey.Replace("-----BEGIN PRIVATE KEY-----", "").Replace("-----END PRIVATE KEY-----", "").Replace(Environment.NewLine, "");
                }

                res.Add(privateKey);

                StringWriter swpub = new StringWriter();
                PemWriter pwripub = new PemWriter(swpub);

                pwripub.WriteObject(keyPair.Public);
                pwripub.Writer.Close();

                string publicKey = swpub.ToString();
                if (!format)
                {
                    publicKey = publicKey.Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", "").Replace(Environment.NewLine, "");
                }
                res.Add(publicKey);
            }
            catch (Exception ex)
            {

            }

            return res;
        }
    }
}
