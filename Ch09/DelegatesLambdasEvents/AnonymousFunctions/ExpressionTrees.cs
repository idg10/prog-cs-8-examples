using System;
using System.Linq.Expressions;

namespace AnonymousFunctions
{
    public static class ExpressionTrees
    {
        public static void LambdaExpression()
        {
            Expression<Func<int, bool>> greaterThanZero = value => value > 0;
        }

        public static void HowTheCompilerCompilesLambdaExpression()
        {
            ParameterExpression valueParam = Expression.Parameter(typeof(int), "value");
            ConstantExpression constantZero = Expression.Constant(0);
            BinaryExpression comparison = Expression.GreaterThan(valueParam, constantZero);
            Expression<Func<int, bool>> greaterThanZero =
                Expression.Lambda<Func<int, bool>>(comparison, valueParam);

            Console.WriteLine(greaterThanZero);
        }
    }
}