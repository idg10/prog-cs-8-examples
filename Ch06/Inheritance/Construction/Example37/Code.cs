using System;

namespace Construction.Example37
{
    public class BaseWithZeroArgCtor
    {
        public BaseWithZeroArgCtor()
        {
            Console.WriteLine("Base constructor");
        }
    }

    public class DerivedNoDefaultCtor : BaseWithZeroArgCtor
    {
        public DerivedNoDefaultCtor(int i)
        {
            Console.WriteLine("Derived constructor");
        }
    }
}
