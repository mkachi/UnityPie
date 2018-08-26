using UnityEngine;

namespace Pie
{
    public class PoolItem
        : MonoBehaviour
    {
        private ObjectPool _pool = null;

        public void SetPool(ObjectPool pool)
        {
            _pool = pool;
        }

        void OnDisable()
        {
            _pool.Add(gameObject);
        }
    }
}