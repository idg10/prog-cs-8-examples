using System.Collections.Generic;

namespace Dictionaries
{
    public static class Initializers
    {
        public static void CollectionInitializer()
        {
            var textToNumber = new Dictionary<string, int>
            {
                { "One", 1 },
                { "Two", 2 },
                { "Three", 3 },
            };
        }

        public static void ObjectInitializer()
        {
            var textToNumber = new Dictionary<string, int>
            {
                ["One"] = 1,
                ["Two"] = 2,
                ["Three"] = 3
            };
        }
    }
}
