using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace QueryExpressions
{
    class Program
    {
        static void Main()
        {
        }

        public static void QueryExpression()
        {
            IEnumerable<CultureInfo> commaCultures =
                from culture in CultureInfo.GetCultures(CultureTypes.AllCultures)
                where culture.NumberFormat.NumberDecimalSeparator == ","
                select culture;

            foreach (CultureInfo culture in commaCultures)
            {
                Console.WriteLine(culture.Name);
            }
        }

        public static void WithoutLinq()
        {
            CultureInfo[] allCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (CultureInfo culture in allCultures)
            {
                if (culture.NumberFormat.NumberDecimalSeparator == ",")
                {
                    Console.WriteLine(culture.Name);
                }
            }
        }

        public static void ExtractingOneProperty()
        {
            IEnumerable<string> commaCultures =
                from culture in CultureInfo.GetCultures(CultureTypes.AllCultures)
                where culture.NumberFormat.NumberDecimalSeparator == ","
                select culture.Name;

            foreach (string cultureName in commaCultures)
            {
                Console.WriteLine(cultureName);
            }
        }

        public static void EffectOfQueryExpression()
        {
            IEnumerable<string> commaCultures =
                CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Where(culture => culture.NumberFormat.NumberDecimalSeparator == ",")
                .Select(culture => culture.Name);
        }

        public static void ExpansionOfTrivialSelect()
        {
            IEnumerable<CultureInfo> commaCultures =
                CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Where(culture => culture.NumberFormat.NumberDecimalSeparator == ",");
        }

        public static void QueryWithLetClause()
        {
            IEnumerable<string> commaCultures =
                from culture in CultureInfo.GetCultures(CultureTypes.AllCultures)
                let numFormat = culture.NumberFormat
                where numFormat.NumberDecimalSeparator == ","
                select culture.Name;
        }

        public static void ExpansionOfMultiVariableQueryExpression()
        {
            IEnumerable<string> commaCultures =
                CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Select(culture => new { culture, numFormat = culture.NumberFormat })
                .Where(vars => vars.numFormat.NumberDecimalSeparator == ",")
                .Select(vars => vars.culture.Name);
        }

        public static void MeaninglessQuery()
        {
            var q = from x in new SillyLinqProvider()
                    where int.Parse(x)
                    select x.Hour;
        }

        public static void EffectOfMeaninglessQuery()
        {
            var q = new SillyLinqProvider().Where(x => int.Parse(x)).Select(x => x.Hour);
        }

        public static void AccidentalReevaluation()
        {
            var commaCultures =
                from culture in CultureInfo.GetCultures(CultureTypes.AllCultures)
                where culture.NumberFormat.NumberDecimalSeparator == ","
                select culture;

            object[] numbers = { 1, 100, 100.2, 10000.2 };

            foreach (object number in numbers)
            {
                foreach (CultureInfo culture in commaCultures)
                {
                    Console.WriteLine(string.Format(culture, "{0}: {1:c}",
                                      culture.Name, number));
                }
            }
        }

        // The next examples illustrate types defined by .NET. Since .NET defines
        // these, we do not want to define our own versions, hence the #if false
#if false
        public interface IQueryable : IEnumerable
        {
            Type ElementType { get; }
            Expression Expression { get; }
            IQueryProvider Provider { get; }
        }

        public interface IQueryable<out T> : IEnumerable<T>, IQueryable
        {
        }

        public interface IQueryProvider
        {
            IQueryable CreateQuery(Expression expression);
            IQueryable<TElement> CreateQuery<TElement>(Expression expression);
            object Execute(Expression expression);
            TResult Execute<TResult>(Expression expression);
        }

        public static class Enumerable
        {
            public static IEnumerable<TSource> Where<TSource>(
                this IEnumerable<TSource> source,
                Func<TSource, bool> predicate)
            ...
        }

        public static class Queryable
        {
            public static IQueryable<TSource> Where<TSource>(
                this IQueryable<TSource> source,
                Expression<Func<TSource, bool>> predicate)
            ...
        }
#endif
    }
}
