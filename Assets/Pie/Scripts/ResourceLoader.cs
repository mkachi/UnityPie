using UnityEngine;
using System.Collections.Generic;

namespace Pie
{
    public static class ResourceLoader
    {
        private static Dictionary<string, UnityEngine.Object> _hash = new Dictionary<string, UnityEngine.Object>();

        public static T Get<T>(string path) where T : UnityEngine.Object
        {
            if (!_hash.ContainsKey(path))
            {
                UnityEngine.Object result = Resources.Load(path);
                _hash.Add(path, result);
                return result as T;
            }
            return _hash[path] as T;
        }

        public static void UnLoad(params string[] keys)
        {
            for (int i = 0; i < keys.Length; ++i)
            {
                _hash.Remove(keys[i]);
            }
        }

        public static void UnLoadAll()
        {
            _hash.Clear();
        }
    }
}