using System;
using Properties.Auto;

namespace Properties
{
    class Program
    {
        static void Main()
        {
            var o = new HasProperty();
            o.X = 123;
            o.X += 432;
            Console.WriteLine(o.X);
        }
    }
}