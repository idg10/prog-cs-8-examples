using System;
using System.Reflection;

namespace DeclaringVsReflected
{
    class Base
    {
        public void Foo()
        {
        }
    }

    class Derived : Base
    {
    }

    class Program
    {
        static void Main(string[] args)
        {
            MemberInfo bf = typeof(Base).GetMethod("Foo");
            MemberInfo df = typeof(Derived).GetMethod("Foo");

            Console.WriteLine("Base    Declaring: {0}, Reflected: {1}",
                              bf.DeclaringType, bf.ReflectedType);
            Console.WriteLine("Derived Declaring: {0}, Reflected: {1}",
                              df.DeclaringType, df.ReflectedType);
        }
    }
}