using System;

namespace Boxing
{
    public static class Unboxing
    {
        public static void UnboxWithTypePattern(object o)
        {
            if (o is int i)
            {
                Console.WriteLine(i * 2);
            }
        }

        public static void UnboxToNullableAndNonNullable()
        {
            object boxed = 42;
            int? nv = boxed as int?;
            int? nv2 = (int?)boxed;
            int v = (int)boxed;

            Console.WriteLine($"{nv}, {nv2}, {v}");
        }
    }
}
