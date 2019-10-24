using System.Collections.Generic;

namespace Nullability
{
    public class NonNullableAwareTryPattern
    {
        // If you add this:
        // #nullable enable
        // You'll see a warning on the line that calls TryGetValue.
        public static string Get(IDictionary<int, string> d)
        {
            if (d.TryGetValue(42, out string s))
            {
                return s;
            }

            return "Not found";
        }
    }
}
