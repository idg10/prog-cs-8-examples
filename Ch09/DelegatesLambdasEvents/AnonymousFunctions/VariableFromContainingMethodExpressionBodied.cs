using System;

namespace AnonymousFunctions
{
    public static class VariableFromContainingMethodExpressionBodied
    {
        public static Predicate<int> IsGreaterThan(int threshold) =>
            value => value > threshold;

        public static void WhereValueComesFrom()
        {
            Predicate<int> greaterThanTen = IsGreaterThan(10);
            bool result = greaterThanTen(200);

            Console.WriteLine(result);
        }
    }
}