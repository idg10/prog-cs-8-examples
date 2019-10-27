using System;

namespace Boxing
{
    class Program
    {
        static void Show(object o)
        {
            Console.WriteLine(o.ToString());
        }

        static void Main(string[] args)
        {
            int num = 42;
            Show(num);
        }
    }
}
