using System.Linq;

namespace StandardOperators
{
    public static class Ordering
    {
        public static void OrderedQueryExpression()
        {
            var q = from course in Course.Catalog
                    orderby course.PublicationDate ascending
                    select course;
        }

        public static void WrongMultipleOrderingCriteria()
        {
            var q = from course in Course.Catalog
                    orderby course.PublicationDate ascending
                    orderby course.Duration descending // BAD! Could discard previous order
                    select course;
        }

        public static void MultipleOrderingCriteria()
        {
            var q = from course in Course.Catalog
                    orderby course.PublicationDate ascending, course.Duration descending
                    select course;
        }

        public static void MultipleOrderingCriteriaDirectOperatorUse()
        {
            var q = Course.Catalog
                .OrderBy(course => course.PublicationDate)
                .ThenByDescending(course => course.Duration);
        }
    }
}