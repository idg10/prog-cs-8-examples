using System;
using System.Reflection;

namespace ReflectionContexts
{
    class Program
    {
        static void Main()
        {
            var ctx = new MyReflectionContext();
            TypeInfo mappedType = ctx.MapType(typeof(NotVeryInteresting).GetTypeInfo());

            foreach (PropertyInfo prop in mappedType.DeclaredProperties)
            {
                Console.WriteLine($"{prop.Name} ({prop.PropertyType.Name})");
            }
        }
    }
}