using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Context;

namespace ReflectionContexts
{
    class NotVeryInteresting
    {
    }

    class MyReflectionContext : CustomReflectionContext
    {
        protected override IEnumerable<PropertyInfo> AddProperties(Type type)
        {
            if (type == typeof(NotVeryInteresting))
            {
                var fakeProp = CreateProperty(
                    MapType(typeof(string).GetTypeInfo()),
                    "FakeProperty",
                    o => "FakeValue",
                    (o, v) => Console.WriteLine($"Setting value: {v}"));

                return new[] { fakeProp };
            }
            else
            {
                return base.AddProperties(type);
            }
        }
    }
}