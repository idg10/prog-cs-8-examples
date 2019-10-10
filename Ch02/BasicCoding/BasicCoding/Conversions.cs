using System;
using System.Threading;

namespace BasicCoding
{
    internal static class Conversions
    {
        internal static void ImplicitConversions()
        {
            int i = 42;
            double di = i;
            Console.WriteLine(i / 5);
            Console.WriteLine(di / 5);
            Console.WriteLine(i / 5.0);
        }

        // To see the compiler error for Example 34, change this:
#if false
//  to:
// #if true
        internal static void InvalidImplicitConversions()
        {
            int i = 42;
            int willFail = 42.0;
            int willAlsoFail = i / 1.0;
        }
#endif

        internal static void ExplicitConversions()
        {
            int i = 42;
            int i2 = (int)42.0;
            int i3 = (int)(i / 1.0);

            Console.WriteLine($"{i2}, {i3}");
        }

        internal static void IntentionalOverflow()
        {
            int start = Environment.TickCount;
            DoSomeWork();
            int end = Environment.TickCount;

            int totalTicks = end - start;
            Console.WriteLine(totalTicks);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "These examples just illustrate syntax")]
        internal static void CheckedExpressions()
        {
            int a = 2_000_000_000;
            int b = 500_000_000;
            int c = 42;

            int result = checked(a + b) + c;

            checked
            {
                int r1 = a + b;
                int r2 = r1 - (int)c;
            }
        }

        private static void DoSomeWork() => Thread.Sleep(100);
    }
}
