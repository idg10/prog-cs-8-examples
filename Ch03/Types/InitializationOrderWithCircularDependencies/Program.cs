using System;

namespace InitializationOrderWithCircularDependencies
{
    public class AfterYou
    {
        static AfterYou()
        {
            Console.WriteLine("AfterYou static constructor starting");
            Console.WriteLine("AfterYou: NoAfterYou.Value = " + NoAfterYou.Value);
            Value = 123;
            Console.WriteLine("AfterYou static constructor ending");
        }

        public static int Value = 42;
    }

    public class NoAfterYou
    {
        static NoAfterYou()
        {
            Console.WriteLine("NoAfterYou static constructor starting");
            Console.WriteLine("NoAfterYou: AfterYou.Value: = " + AfterYou.Value);
            Value = 456;
            Console.WriteLine("NoAfterYou static constructor ending");
        }

        public static int Value = 42;
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine(AfterYou.Value); ;
        }
    }
}
