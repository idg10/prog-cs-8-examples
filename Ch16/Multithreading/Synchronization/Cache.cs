using System.Collections.Generic;
using System.Threading;

namespace Synchronization
{
    public class Cache<T>
    {
        private static Dictionary<string, T> _d;

        public static IDictionary<string, T> Dictionary =>
            LazyInitializer.EnsureInitialized(ref _d);
    }
}