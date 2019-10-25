using System;

namespace GenericsAndTuples
{
    class Program
    {
        static void Main()
        {
            (int, int) p = (42, 99);

            ValueTuple<int, int> p2 = (42, 99);

            Console.WriteLine(p);
            Console.WriteLine(p2);
            Console.WriteLine(new Program().Pos());
        }

        public (int X, int Y) Pos() => (10, 20);
    }
}