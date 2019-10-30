using System;
using System.Collections.Generic;
using System.Linq;

namespace StandardOperators
{
    public static class Conversion
    {
        public static void HowNotToCastSequence()
        {
            IEnumerable<object> sequence = Course.Catalog.Select(c => (object)c);
            var courseSequence = (IEnumerable<Course>)sequence; // InvalidCastException
        }

        public static void CastSequence()
        {
            IEnumerable<object> sequence = Course.Catalog.Select(c => (object)c);

            var courseSequence = sequence.Cast<Course>();
        }

        public static void CreateLookup()
        {
            ILookup<string, Course> categoryLookup =
                Course.Catalog.ToLookup(course => course.Category);
            foreach (Course c in categoryLookup["MAT"])
            {
                Console.WriteLine(c.Title);
            }
        }
    }
}