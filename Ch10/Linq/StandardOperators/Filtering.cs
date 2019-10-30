using System;
using System.Collections.Generic;
using System.Linq;

namespace StandardOperators
{
    public static class Filtering
    {
        public static void WhereWithIndex()
        {
            IEnumerable<Course> q = Course.Catalog.Where(
                (course, index) => (index % 2 == 0) && course.Duration.TotalHours >= 3);
        }

        static void ShowAllStrings(IEnumerable<object> src)
        {
            foreach (string s in src.OfType<string>())
            {
                Console.WriteLine(s);
            }
        }
    }
}