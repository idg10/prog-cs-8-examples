using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace StandardOperators
{
    public static class Aggregation
    {
        private static readonly IEnumerable<Course> mathsCourses = Course.Catalog.Where(c => c.Category == "MAT");

        public static void AverageOperator()
        {
            Console.WriteLine("Average course length in hours: {0}",
                Course.Catalog.Average(course => course.Duration.TotalHours));
        }

        public static void MaxOperatorWithProjection()
        {
            DateTime m = mathsCourses.Max(c => c.PublicationDate);
        }

        public static void SumAndEquivalentViaAggregateOperator()
        {
            double t1 = Course.Catalog.Sum(course => course.Duration.TotalHours);
            double t2 = Course.Catalog.Aggregate(
                0.0, (hours, course) => hours + course.Duration.TotalHours);
        }

        public static void ImplementingMaxWithAggregate()
        {
            DateTime m = mathsCourses.Aggregate(
                new DateTime(),
                (date, c) => date > c.PublicationDate ? date : c.PublicationDate);
        }

        public static void ImplementingAverageWithAggregate()
        {
            double average = Course.Catalog.Aggregate(
                new { TotalHours = 0.0, Count = 0 },
                (totals, course) => new
                {
                    TotalHours = totals.TotalHours + course.Duration.TotalHours,
                    Count = totals.Count + 1
                },
                totals => totals.Count >= 0
                    ? totals.TotalHours / totals.Count
                    : throw new InvalidOperationException("Sequence was empty"));
        }

        public static Rect GetBounds(IEnumerable<Rect> rects) =>
            rects.Aggregate(Rect.Union);

        public class MoreVerboseAndLessObscure
        {
            public static Rect GetBounds(IEnumerable<Rect> rects)
            {
                IEnumerable<Rect> theRest = rects.Skip(1);
                return theRest.Aggregate(rects.First(), (r1, r2) => Rect.Union(r1, r2));
            }
        }

        public static void TheEffectOfAggregate()
        {
            var r1 = new Rect();
            var r2 = new Rect(10, 10, 20, 20);
            var r3 = new Rect(-100, 10, 20, 20);
            var r4 = new Rect(10, -200, 20, 20);

            Rect bounds = Rect.Union(Rect.Union(Rect.Union(r1, r2), r3), r4);
        }
    }
}