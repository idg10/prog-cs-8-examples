using System;
using System.Linq;

namespace StandardOperators
{
    public static class Subranges
    {
        public static void SingleOperator()
        {
            var q = from course in Course.Catalog
                    where course.Category == "MAT" && course.Number == 101
                    select course;

            Course geometry = q.Single();
        }

        public static void SingleOperatorWithPredicate()
        {
            Course geometry = Course.Catalog.Single(
                course => course.Category == "MAT" && course.Number == 101);
        }
    
        public static void FirstOperator()
        {
            var q = from course in Course.Catalog
                    orderby course.Duration descending
                    select course;
            Course longest = q.First();
        }

        public static void BadUseOfElementAt()
        {
            var mathsCourses = Course.Catalog.Where(c => c.Category == "MAT");
            for (int i = 0; i < mathsCourses.Count(); ++i)
            {
                // Never do this!
                Course c = mathsCourses.ElementAt(i);
                Console.WriteLine(c.Title);
            }
        }
    }
}