using System;
using System.Reflection;

namespace ReflectionTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly me = typeof(Program).Assembly;
            Console.WriteLine(me.FullName);
        }
    }
}