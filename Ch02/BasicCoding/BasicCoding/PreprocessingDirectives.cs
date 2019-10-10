using System;

namespace BasicCoding
{
    internal class PreprocessingDirectives
    {
        internal static void ConditionalCompilation()
        {
#if DEBUG
            Console.WriteLine("Starting work");
#endif
            DoWork();
#if DEBUG
            Console.WriteLine("Finished work");
#endif
        }

        [System.Diagnostics.Conditional("DEBUG")]
        static void ShowDebugInfo(object o)
        {
            Console.WriteLine(o);
        }

        internal static void ErrorDirective()
        {
#if NETSTANDARD
    #error .NET Standard is not a supported target for this source file
#endif
        }

// To see the compiler error for Example 31, change this:
#if false
//  to:
// #if true

#line 123 "Foo.cs"
        intt x;
#endif

#pragma warning disable CS0168
        int a;

        private static void DoWork() { }

        internal static void AvoidUnusedMethodWarning() => ShowDebugInfo("");
    }
}
