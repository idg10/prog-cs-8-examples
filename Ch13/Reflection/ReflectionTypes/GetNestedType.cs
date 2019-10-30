using System;

namespace ReflectionTypes
{
    public static class GetNestedType
    {
        public static void Get()
        {
            var someAssembly = typeof(GetNestedType).Assembly;

            Type nt = someAssembly.GetType("MyLib.ContainingType+Inside");
        }
    }
}