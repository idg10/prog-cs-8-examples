using System;
using System.Collections.Generic;

namespace QueryInifiniteSource
{
    public static class CustomDeferredLinqProvider
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> src,
                                              Func<T, bool> filter)
        {
            foreach (T item in src)
            {
                if (filter(item))
                {
                    yield return item;
                }
            }
        }
    }
}