using System;

namespace DelegatesOtherClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> p1 = Tests.IsGreaterThanZero;
            Predicate<int> p2 = Tests.IsLessThanZero;
        }
    }

    internal class Tests
    {
        public static bool IsGreaterThanZero(int value) => value > 0;

        public static bool IsLessThanZero(int value) => value < 0;
    }
}