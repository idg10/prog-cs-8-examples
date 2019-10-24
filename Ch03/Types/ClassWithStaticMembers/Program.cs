using System;

namespace ClassWithStaticMembers
{
    class Program
    {
        static void Main()
        {
            var c1 = new Counter();
            var c2 = new Counter();
            Console.WriteLine("c1: " + c1.GetNextValue());
            Console.WriteLine("c1: " + c1.GetNextValue());
            Console.WriteLine("c1: " + c1.GetNextValue());

            Console.WriteLine("c2: " + c2.GetNextValue());

            Console.WriteLine("c1: " + c1.GetNextValue());

            Console.WriteLine(Counter.TotalCount);
        }
    }
}
