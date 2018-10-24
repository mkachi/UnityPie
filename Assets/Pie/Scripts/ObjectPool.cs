using UnityEngine;
using System.Collections.Generic;
using System.Text;

namespace Pie
{
    public class ObjectPool
    {
        private Queue<GameObject> _pools = null;
        public int MaxSize { get; private set; }

        public ObjectPool(GameObject prefab, int size)
        {
            MaxSize = size;
            _pools = new Queue<GameObject>();
#if UNITY_EDITOR
            StringBuilder sb = new StringBuilder();
#endif
            for (int i = 0; i < size; ++i)
            {
                GameObject item = GameObject.Instantiate(prefab) as GameObject;
                item.SetActive(false);
                item.AddComponent<PoolItem>().SetPool(this);
#if UNITY_EDITOR
                sb.Remove(0, sb.Length);
                sb.Append("[Pool : ").Append(i).Append("]");
                item.name = item.name.Replace("(clone)", sb.ToString());
#endif
                _pools.Enqueue(item);
            }
        }

        public ObjectPool(GameObject prefab, int size, Transform parent)
        {
            MaxSize = size;
            _pools = new Queue<GameObject>();
#if UNITY_EDITOR
            StringBuilder sb = new StringBuilder();
#endif
            for (int i = 0; i < size; ++i)
            {
                GameObject item = GameObject.Instantiate(prefab) as GameObject;
                item.SetActive(false);
                item.AddComponent<PoolItem>().SetPool(this);
                item.transform.SetParent(parent);
#if UNITY_EDITOR
                sb.Remove(0, sb.Length);
                sb.Append("[Pool : ").Append(i).Append("]");
                item.name = item.name.Replace("(clone)", sb.ToString());
#endif
                _pools.Enqueue(item);
            }
        }

        public void Add(GameObject item)
        {
            _pools.Enqueue(item);
        }

        public GameObject Peek(bool active = true)
        {
            if (_pools.Count > 0)
            {
                GameObject result = _pools.Dequeue();
                result.SetActive(active);
                return result;
            }
            return null;
        }
    }
}