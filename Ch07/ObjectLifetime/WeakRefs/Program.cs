using System;
using System.Runtime.CompilerServices;

namespace WeakRefs
{
    class Program
    {
        static WeakCache<string, byte[]> cache = new WeakCache<string, byte[]>();
        static byte[] data = new byte[100];

        static void Main(string[] args)
        {
            AddData();
            CheckStillAvailable();

            GC.Collect();
            CheckStillAvailable();

            SetOnlyRootToNull();
            GC.Collect();
            CheckNoLongerAvailable();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void AddData()
        {
            cache.Add("d", data);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void CheckStillAvailable()
        {
            Console.WriteLine("Retrieval: " +
                cache.TryGetValue("d", out byte[] fromCache));
            Console.WriteLine("Same ref?  " +
                object.ReferenceEquals(data, fromCache));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void SetOnlyRootToNull()
        {
            data = null;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void CheckNoLongerAvailable()
        {
            byte[] fromCache;
            Console.WriteLine("Retrieval: " + cache.TryGetValue("d", out fromCache));
            Console.WriteLine("Null?  " + (fromCache == null));
        }
    }
}
