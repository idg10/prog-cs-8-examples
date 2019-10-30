using System;
using System.Collections.Generic;

namespace Dictionaries
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
        }

        public static void CaseInsensitive()
        {
            var textToNumber =
                new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "One", 1 },
                { "Two", 2 },
                { "Three", 3 },
            };
        }
    }
}