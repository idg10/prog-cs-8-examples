using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnonymousFunctions
{
    public static class VariableFromContainingMethod
    {
        public static Predicate<int> IsGreaterThan(int threshold)
        {
            return value => value > threshold;
        }

        // This example illustrates what the compiler generates, but since it includes
        // 'unspeakable' names, it can't compile, hence the #if false
#if false
        [CompilerGenerated]
        private sealed class <>c__DisplayClass1_0
        {
            public int threshold;

            public bool <IsGreaterThan>b__0(int value)
            {
                return (value > this.threshold);
            }
        }
#endif
        static void Calculate(int[] nums)
        {
            int zeroCount = 0;
            int[] nonZeroNums = Array.FindAll(
                nums,
                v =>
                {
                    if (v == 0)
                    {
                        zeroCount += 1;
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                });
            Console.WriteLine("Number of zero entries: {zeroCount}");
            Console.WriteLine("First non-zero entry: {nonZeroNums[0]}");
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Code Quality", "IDE0067:Dispose objects before losing scope", Justification = "In most cases you don't need to Dispose an HttpClient - it's an exception to the general rule")]
        public static void PrematureDisposal()
        {
            HttpClient http = GetHttpClient();
            using (FileStream file = File.OpenWrite(@"c:\temp\page.txt"))
            {
                http.GetStreamAsync("https://endjin.com/")
                    .ContinueWith((Task<Stream> t) => t.Result.CopyToAsync(file));
            } // Will probably dispose StreamWriter before callback runs
        }

        private static HttpClient GetHttpClient() => new HttpClient();

        public static void Caught()
        {
            var greaterThanN = new Predicate<int>[10];
            for (int i = 0; i < greaterThanN.Length; ++i)
            {
                greaterThanN[i] = value => value > i; // Bad use of i
            }

            Console.WriteLine(greaterThanN[5](20));
            Console.WriteLine(greaterThanN[5](6));
        }

        public static void FixedCaught()
        {
            var greaterThanN = new Predicate<int>[10];
            for (int i = 0; i < greaterThanN.Length; ++i)
            {
                int current = i;
                greaterThanN[i] = value => value > current;
            }

            Console.WriteLine(greaterThanN[5](20));
            Console.WriteLine(greaterThanN[5](6));
        }

        public static void CaptureAtMultipleScopes()
        {
            var greaterThanN = new Predicate<int>[10];

            int offset = 10;
            for (int i = 0; i < greaterThanN.Length; ++i)
            {
                int current = i;
                    greaterThanN[i] = value => value > (current + offset);
            }
        }
    }
}