using System;
using System.Collections.Generic;

namespace ReflectionTypes
{
    public static class GenericTypeObjects
    {
        public static void Get()
        {
            Type bound = typeof(List<int>);
            Type unbound = typeof(List<>);
        }
    }
}