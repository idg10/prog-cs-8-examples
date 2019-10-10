using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCoding
{
    internal static class StatementsAndExpressions
    {
        internal static void SomeStatements()
        {
            int a = 19;
            int b = 23;
            int c;
            c = a + b;
            Console.WriteLine(c);
        }

        internal static void Block()
        {
            int a = 19;
            int b = 23;
            {
                int c;
                c = a + b;
                Console.WriteLine(c);
            }
        }

        internal static void ExpressionsWithinExpressions()
        {
            double a = 1, b = 2.5, c = -3;
            double x = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            Console.WriteLine(x);
        }

        internal static void MethodInvocationExpressionsAsStatements()
        {
            Console.WriteLine("Hello, world!");
            Console.WriteLine(12 + 30);
            Console.ReadKey();
            Math.Sqrt(4);
        }

// To see the compiler error for Example 5, change this:
#if false
//  to:
// #if true
        internal static void ExpressionsUnacceptableAsStatements()
        {
            Console.ReadKey().KeyChar + "!";
            Math.Sqrt(4) + 1;
        }
#endif

        internal static void AssignmentsAreExpressions()
        {
            int number;
            Console.WriteLine(number = 123);
            Console.WriteLine(number);

            int x, y;
            x = y = 0;
            Console.WriteLine(x);
            Console.WriteLine(y);
        }
    }
}
