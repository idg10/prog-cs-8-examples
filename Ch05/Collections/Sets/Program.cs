using System;
using System.Collections.Generic;

namespace Sets
{
    class Program
    {
        static void Main()
        {
            ShowEachDistinctString(new[] { "Hello World!", "Hello", "World!", "Hello" });
        }

        public static void ShowEachDistinctString(IEnumerable<string> strings)
        {
            var shown = new HashSet<string>();  // Implements ISet<T>
            foreach (string s in strings)
            {
                if (shown.Add(s))
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}