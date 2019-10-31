using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Threading
{
    class Program
    {
        static void Main()
        {
        }

        public static string FormatDictionary<TKey, TValue>(
            IDictionary<TKey, TValue> input)
        {
            var sb = new StringBuilder();
            foreach (var item in input)
            {
                sb.AppendFormat("{0}: {1}", item.Key, item.Value);
                sb.AppendLine();
            }

            return sb.ToString();
        }

        static string UseDictionary(ConcurrentDictionary<int, string> cd)
        {
            cd[1] = "One";
            return cd[1];
        }
    }
}