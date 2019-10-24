using System;
using System.Collections.Generic;

namespace Indexers
{
    class Program
    {
        static void Main()
        {
            var numbers = new List<int> { 1, 2, 1, 4 };
            numbers[2] += numbers[1];
            Console.WriteLine(numbers[0]);

            NullConditionalIndex(null);
            EquivalentOfNullConditionalIndex(null);
        }

        private static void NullConditionalIndex(List<string>? objectWithIndexer)
        {
            string? s = objectWithIndexer?[2];

            Console.WriteLine(s ?? "Null");
        }

        private static void EquivalentOfNullConditionalIndex(List<string>? objectWithIndexer)
        {
            string? s = objectWithIndexer == null ? null : objectWithIndexer[2];

            Console.WriteLine(s ?? "Null");
        }
    }
}