using System.Collections.Generic;

namespace LibraryContainingCustomComparer
{
    public class MyCustomComparer : IComparer<string>
    {
        public int Compare(string x, string y) => 0;
    }
}
