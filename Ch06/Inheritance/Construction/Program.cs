using System;

namespace Construction
{
    class Program
    {
        static void Main()
        {
            new Example37.DerivedNoDefaultCtor(42);

            Console.WriteLine();

            new Example38.DerivedCallingBaseCtor();

            Console.WriteLine();

            new DerivedInit();
        }
    }

    public class BaseInit
    {
        protected static int Init(string message)
        {
            Console.WriteLine(message);
            return 1;
        }

        private int b1 = Init("Base field b1");

        public BaseInit()
        {
            Init("Base constructor");
        }

        private int b2 = Init("Base field b2");
    }

    public class DerivedInit : BaseInit
    {
        private int d1 = Init("Derived field d1");

        public DerivedInit()
        {
            Init("Derived constructor");
        }

        private int d2 = Init("Derived field d2");
    }
}
