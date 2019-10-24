using System;

namespace Operators
{
    class Program
    {
        static void Main()
        {
            var c = (Counter)123;
            var v = (int)c;

            Console.WriteLine(v);
        }
    }
}