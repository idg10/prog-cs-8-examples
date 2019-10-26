using System;

namespace Construction.Example38
{
    public class BaseNoDefaultCtor
    {
        public BaseNoDefaultCtor(int i)
        {
            Console.WriteLine("Base constructor: " + i);
        }
    }

    public class DerivedCallingBaseCtor : BaseNoDefaultCtor
    {
        public DerivedCallingBaseCtor()
            : base(123)
        {
            Console.WriteLine("Derived constructor (default)");
        }

        public DerivedCallingBaseCtor(int i)
            : base(i)
        {
            Console.WriteLine("Derived constructor: " + i);
        }
    }
}