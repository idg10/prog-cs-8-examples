using System;
using System.Collections.Generic;
using System.Linq;

namespace StandardOperators
{
    public static class WholeSequenceOrderPreserving
    {
        public static void CombiningWithZip()
        {
            string[] firstNames = { "Carmel", "Ed", "Arthur", "Arthur" };
            string[] lastNames = { "Eve", "Freeman", "Dent", "Pewty" };
            IEnumerable<string> fullNames = firstNames.Zip(lastNames,
                (first, last) => first + " " + last);
            foreach (string name in fullNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}