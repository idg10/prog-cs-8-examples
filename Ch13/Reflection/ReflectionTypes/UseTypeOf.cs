using System;

namespace ReflectionTypes
{
    public static class UseTypeOf
    {
        public static void Get()
        {
            Type stringType = typeof(string);
            Type disposableType = typeof(IDisposable);
        }
    }
}