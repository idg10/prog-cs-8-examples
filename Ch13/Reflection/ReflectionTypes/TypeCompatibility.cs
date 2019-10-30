using System;

namespace ReflectionTypes
{
    public static class TypeCompatibility
    {
        public static void Test()
        {
            Type stringType = typeof(string);
            Type objectType = typeof(object);
            Console.WriteLine(stringType.IsAssignableFrom(objectType));
            Console.WriteLine(objectType.IsAssignableFrom(stringType));
        }
    }
}