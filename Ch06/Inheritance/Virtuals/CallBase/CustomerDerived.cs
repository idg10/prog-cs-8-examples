using System;
using Library;

namespace Virtuals.CallBase
{
    public class CustomerDerived : LibraryBase
    {
        public override void Start()
        {
            Console.WriteLine("Derived type's Start method");
            base.Start();
        }
    }
}