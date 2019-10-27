using System;
using System.Collections.Generic;

namespace WeakRefs
{
    public class WeakCache<TKey, TValue> where TValue : class
    {
        private readonly Dictionary<TKey, WeakReference<TValue>> _cache =
            new Dictionary<TKey, WeakReference<TValue>>();

        public void Add(TKey key, TValue value)
        {
            _cache.Add(key, new WeakReference<TValue>(value));
        }

        public bool TryGetValue(TKey key, out TValue cachedItem)
        {
            WeakReference<TValue> entry;
            if (_cache.TryGetValue(key, out entry))
            {
                bool isAlive = entry.TryGetTarget(out cachedItem);
                if (!isAlive)
                {
                    _cache.Remove(key);
                }
                return isAlive;
            }
            else
            {
                cachedItem = null;
                return false;
            }
        }
    }
}
