using System;
using System.Collections.Generic;
using System.Linq;

namespace StandardOperators
{
    public static class Projection
    {
        public static void SelectWithIndex()
        {
            IEnumerable<string> nonIntro = Course.Catalog.Select((course, index) =>
                  $"Course {index}: {course.Title}");
        }

        public static void IndexedSelectDownstreamOfWhere()
        {
            IEnumerable<string> nonIntro = Course.Catalog
                .Where(c => c.Number >= 200)
                .Select((course, index) => $"Course {index}: {course.Title}");
        }

        public static void IndexedSelectUpstreamOfWhere()
        {
            IEnumerable<string> nonIntro = Course.Catalog
                .Select((course, index) => new { course, index })
                .Where(vars => vars.course.Number >= 200)
                .Select(vars => $"Course {vars.index}: {vars.course.Title}");
        }

        public static void FetchingMoreThanNeeded()
        {
            using var dbCtx = new ExampleDbContext();

            var pq = from product in dbCtx.Product
                     where product.ListPrice > 3000
                     select product;
            foreach (var prod in pq)
            {
                Console.WriteLine($"{prod.Name} ({prod.Size}): {prod.ListPrice}");
            }
        }

        public static void SelectClauseWithAnonymousType()
        {
            using var dbCtx = new ExampleDbContext();

            var pq = from product in dbCtx.Product
                     where (product.ListPrice > 3000)
                     select new { product.Name, product.ListPrice, product.Size };
            foreach (var prod in pq)
            {
                Console.WriteLine($"{prod.Name} ({prod.Size}): {prod.ListPrice}");
            }
        }

        public static void SelectAsTransform()
        {
            int[] numbers = { 0, 1, 2, 3, 4, 5 };

            IEnumerable<int> doubled = numbers.Select(x => 2 * x);
            IEnumerable<int> squared = numbers.Select(x => x * x);
            IEnumerable<string> numberText = numbers.Select(x => x.ToString());
        }

        public static void SelectManyQueryExpression()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] letters = { "A", "B", "C" };

            IEnumerable<string> combined = from number in numbers
                                           from letter in letters
                                           select letter + number;
            foreach (string s in combined)
            {
                Console.WriteLine(s);
            }
        }

        public static void SelectManyOperator()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] letters = { "A", "B", "C" };

            IEnumerable<string> combined = numbers.SelectMany(
                    number => letters,
                    (number, letter) => letter + number);
        }

        public static void SelectManyFlattenQueryExpression()
        {
            int[][] arrays =
            {
                new[] { 1, 2 },
                new[] { 1, 2, 3, 4, 5, 6 },
                new[] { 1, 2, 4 },
                new[] { 1 },
                new[] { 1, 2, 3, 4, 5 }
            };

            IEnumerable<int> combined = from row in arrays
                                        from number in row
                                        select number;
        }

        public static void SelectManyOperatorWithoutProjection()
        {
            int[][] arrays =
            {
                new[] { 1, 2 },
                new[] { 1, 2, 3, 4, 5, 6 },
                new[] { 1, 2, 4 },
                new[] { 1 },
                new[] { 1, 2, 3, 4, 5 }
            };

            var combined = arrays.SelectMany(row => row);
        }

        static IEnumerable<T2> MySelectMany<T, T2>(
                    this IEnumerable<T> src, Func<T, IEnumerable<T2>> getInner)
        {
            foreach (T itemFromOuterCollection in src)
            {
                IEnumerable<T2> innerCollection = getInner(itemFromOuterCollection);
                foreach (T2 itemFromInnerCollection in innerCollection)
                {
                    yield return itemFromInnerCollection;
                }
            }
        }
    }
}