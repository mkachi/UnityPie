using UnityEngine;
using System.Security.Cryptography;
using System.Reflection;
using System;
using Pie.Attributes;

namespace Pie.Security
{
    public class CryptoScriptLoader
        : MonoBehaviour
    {
        [SerializeField]
        private string _key;
        [SerializeField]
        private string _iv;
        [SerializeField]
        private TextAsset _assembly;

        void Awake()
        {
            byte[] buffer = Convert.FromBase64String(_assembly.text);
            byte[] key = StringToByteArray(_key);
            byte[] iv = StringToByteArray(_iv);

            RC2 rc2 = new RC2CryptoServiceProvider();
            rc2.Mode = CipherMode.CBC;

            ICryptoTransform xTrans = rc2.CreateDecryptor(key, iv);
            byte[] decrypted = xTrans.TransformFinalBlock(buffer, 0, buffer.Length);

            Assembly asm = Assembly.Load(decrypted);
            string typeName = _assembly.name.Replace(".txt", "");
            Type encryptClass = asm.GetType(typeName);

            gameObject.AddComponent(encryptClass);
        }

        private static byte[] StringToByteArray(string value)
        {
            int length = value.Length;
            byte[] result = new byte[length / 2];

            for (int i = 0; i < length; i += 2)
            {
                result[i / 2] = Convert.ToByte(value.Substring(i, 2), 16);
            }
            return result;
        }
    }
}