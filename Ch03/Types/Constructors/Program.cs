using System;
using Constructors.Simple;

namespace Constructors
{
    class Program
    {
        static void Main()
        {
            var item1 = new Item(9.99M, "Hammer");

            Console.WriteLine(item1);
        }

        // Change to #if true to see compilation error
#if false
        static void WillNotCompile()
        {
            Uri oops = new Uri();  // Will not compile
        }
#endif
    }
}
