using System;

namespace Bases
{
    public class SomeClass
    {
    }

    public class Derived : SomeClass
    {
    }

    public class AlsoDerived : SomeClass, IDisposable
    {
        public void Dispose() { }
    }
}