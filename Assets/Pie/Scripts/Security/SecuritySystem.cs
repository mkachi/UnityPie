using System.Security.Cryptography;
using System.Text;
using System.IO;
using System;

namespace Pie.Security
{
    public static class SecuritySystem
    {
        private static int _randomHash = 0;
        public static int RandomHash
        {
            get
            {
                if (_randomHash.Equals(0))
                {
                    _randomHash = (
                        UnityEngine.Random.Range(0, 1000000) +
                        UnityEngine.Random.Range(0, 1000000) +
                        UnityEngine.Random.Range(0, 1000000)).GetHashCode();
                }
                return _randomHash;
            }
        }

        public static string Encrypt(string key, string value)
        {
            MD5 hash = MD5.Create();
            byte[] hashData = hash.ComputeHash(Encoding.UTF8.GetBytes(key));
            string hashKey = Encoding.UTF8.GetString(hashData);
            byte[] secret = hash.ComputeHash(Encoding.UTF8.GetBytes(hashKey));

            RijndaelManaged rijndael = new RijndaelManaged();
            rijndael.KeySize = 256;
            rijndael.BlockSize = 128;
            rijndael.Mode = CipherMode.ECB;
            rijndael.Padding = PaddingMode.PKCS7;
            rijndael.Key = secret;
            rijndael.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            ICryptoTransform encrypt = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);
            byte[] xbuffer = null;

            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, encrypt, CryptoStreamMode.Write))
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(value);
                    cStream.Write(buffer, 0, buffer.Length);
                }
                xbuffer = mStream.ToArray();
            }

            string result = Convert.ToBase64String(xbuffer);
            return result;
        }
        public static string Decrypt(string key, string value)
        {
            MD5 hash = MD5.Create();
            byte[] hashData = hash.ComputeHash(Encoding.UTF8.GetBytes(key));
            string hashKey = Encoding.UTF8.GetString(hashData);
            byte[] secret = hash.ComputeHash(Encoding.UTF8.GetBytes(hashKey));

            RijndaelManaged rijndael = new RijndaelManaged();
            rijndael.KeySize = 256;
            rijndael.BlockSize = 128;
            rijndael.Mode = CipherMode.ECB;
            rijndael.Padding = PaddingMode.PKCS7;
            rijndael.Key = secret;
            rijndael.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            ICryptoTransform decrypt = rijndael.CreateDecryptor();
            byte[] xbuffer = null;

            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, decrypt, CryptoStreamMode.Write))
                {
                    byte[] buffer = Convert.FromBase64String(value);
                    cStream.Write(buffer, 0, buffer.Length);
                }
                xbuffer = mStream.ToArray();
            }

            string result = Encoding.UTF8.GetString(xbuffer);
            return result;
        }
    }
}