using System;
using System.Diagnostics;

namespace AnonymousFunctions
{
    public static class AnonymousMethodSyntax
    {
        public static int GetIndexOfFirstNonEmptyBin(int[] bins)
        {
            return Array.FindIndex(
                bins,
                delegate (int value) { return value > 0; }
            );
        }

        public static void IgnoringArguments()
        {
            EventHandler clickHandler = delegate { Debug.WriteLine("Clicked!"); };

            clickHandler(new object(), EventArgs.Empty);
        }
    }
}