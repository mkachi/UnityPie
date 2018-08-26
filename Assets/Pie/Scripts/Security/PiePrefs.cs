using UnityEngine;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.IO;
using System;

namespace Pie.Security
{
    public sealed class PiePrefs
    {
        private static string _key = string.Empty;
        public static string KEY
        {
            get
            {
                if (_key.Equals(string.Empty) || _key.Equals(""))
                {
                    Debug.LogError("PiePrefs KEY is empty!");
                }
                return _key;
            }

            set
            {
                _key = value;
            }
        }

        public static void DeleteAll()
        {
            PlayerPrefs.DeleteAll();
        }
        public static void DeleteKey(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }

        public static void SetFloat(string key, float value)
        {
            PlayerPrefs.SetString(key, SecuritySystem.Encrypt(KEY, value.ToString()));
        }
        public static void SetInt(string key, int value)
        {
            PlayerPrefs.SetString(key, SecuritySystem.Encrypt(KEY, value.ToString()));
        }
        public static void SetString(string key, string value)
        {
            PlayerPrefs.SetString(key, SecuritySystem.Encrypt(KEY, value.ToString()));
        }
        public static void SetObject<T>(string key, T value)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, value);

            string result = Convert.ToBase64String(stream.GetBuffer());
            PlayerPrefs.SetString(key, SecuritySystem.Encrypt(KEY, result));
            stream.Close();
        }

        public static T GetObject<T>(string key)
        {
            string data = SecuritySystem.Decrypt(KEY, PlayerPrefs.GetString(key));
            byte[] buffer = Convert.FromBase64String(data);
            MemoryStream stream = new MemoryStream(buffer);
            BinaryFormatter formatter = new BinaryFormatter();
            stream.Position = 0;

            T result = (T)formatter.Deserialize(stream);
            stream.Close();

            return result;
        }

        public static float GetFloat(string key, float defaultValue = 0.0f)
        {
            string value = SecuritySystem.Decrypt(KEY, PlayerPrefs.GetString(key));
            float result;
            if (float.TryParse(value, out result))
            {
                return result;
            }
            return defaultValue;
        }
        public static int GetInt(string key, int defaultValue = 0)
        {
            string value = SecuritySystem.Decrypt(KEY, PlayerPrefs.GetString(key));
            int result;
            if (int.TryParse(value, out result))
            {
                return result;
            }
            return defaultValue;
        }
        public static string GetString(string key, string defaultValue = "")
        {
            if (!PlayerPrefs.HasKey(key))
            {
                return defaultValue;
            }
            string result = SecuritySystem.Decrypt(KEY, PlayerPrefs.GetString(key));
            return result;
        }

        public static bool HasKey(string key)
        {
            return PlayerPrefs.HasKey(key);
        }
        public static void Save()
        {
            PlayerPrefs.Save();
        }
    }
}