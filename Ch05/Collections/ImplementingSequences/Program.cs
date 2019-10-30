using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImplementingSequences
{
    class Program
    {
        public static IEnumerable<int> Countdown(int start, int end)
        {
            for (int i = start; i >= end; --i)
            {
                yield return i;
            }
        }

        private static void Main(string[] args)
        {
            foreach (int i in Countdown(5, 1))
            {
                Console.WriteLine(i);
            }
        }

        public static IEnumerable<int> ThreeNumbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }

        public static IEnumerable<BigInteger> Fibonacci()
        {
            BigInteger v1 = 1;
            BigInteger v2 = 1;

            while (true)
            {
                yield return v1;
                var tmp = v2;
                v2 = v1 + v2;
                v1 = tmp;
            }
        }
    }
}