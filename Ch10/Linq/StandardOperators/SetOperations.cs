using System.Linq;

namespace StandardOperators
{
    public static class SetOperations
    {
        public static void DistinctOperator()
        {
            var categories = Course.Catalog.Select(c => c.Category).Distinct();
        }
    }
}
