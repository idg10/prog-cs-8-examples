using System;
using System.Reflection;

namespace Delegates
{
    class Program
    {
        static void Main()
        {
        }

        public static int GetIndexOfFirstNonEmptyBin(int[] bins) =>
            Array.FindIndex(bins, IsGreaterThanZero);

        private static bool IsGreaterThanZero(int value) => value > 0;

        // These examples illustrates how various types and members declared. Since these are all
        // defined by .NET, we don't in fact need to define them ourselves, hence the #if false.
#if false
        public static int FindIndex<T>(
              T[] array,
              Predicate<T> match
          )

        public delegate bool Predicate<in T>(T obj);

        public delegate void Action();
        public delegate void Action<in T1>(T1 arg1);
        public delegate void Action<in T1, in T2 >(T1 arg1, T2 arg2);
        public delegate void Action<in T1, in T2, in T3>(T1 arg1, T2 arg2, T3 arg3);

        public delegate TResult Func<out TResult>();
        public delegate TResult Func<in T1, out TResult>(T1 arg1);
        public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
        public delegate TResult Func<in T1, in T2, in T3, out TResult>(
            T1 arg1, T2 arg2, T3 arg3);

        public Predicate(object target, IntPtr method);

        public bool Invoke(T obj);

        public IAsyncResult BeginInvoke(T obj, AsyncCallback callback, object state);
        public bool EndInvoke(IAsyncResult result);
#endif

        public static void ConstructingADelegate()
        {
            var p = new Predicate<int>(IsGreaterThanZero);

            Console.WriteLine(p(42));
        }

        public static void ImplicitDelegateCreation()
        {
            Predicate<int> p = IsGreaterThanZero;

            Console.WriteLine(p(42));
        }

        public static void ExplicitInstance()
        {
            var zeroThreshold = new ThresholdComparer { Threshold = 0 };
            var tenThreshold = new ThresholdComparer { Threshold = 10 };
            var hundredThreshold = new ThresholdComparer { Threshold = 100 };

            Predicate<int> greaterThanZero = zeroThreshold.IsGreaterThan;
            Predicate<int> greaterThanTen = tenThreshold.IsGreaterThan;
            Predicate<int> greaterThanOneHundred = hundredThreshold.IsGreaterThan;

            Console.WriteLine(greaterThanZero(42));
            Console.WriteLine(greaterThanTen(42));
            Console.WriteLine(greaterThanOneHundred(42));

            Predicate<int> megaPredicate1 =
                greaterThanZero + greaterThanTen + greaterThanOneHundred;

            Predicate<int> megaPredicate2 = greaterThanZero;
            megaPredicate2 += greaterThanTen;
            megaPredicate2 += greaterThanOneHundred;
        }

        public static void UsingCreateDelegate()
        {
            var zeroThreshold = new ThresholdComparer { Threshold = 0 };

            MethodInfo m = typeof(ThresholdComparer).GetMethod("IsGreaterThan");
            var greaterThanZero = (Predicate<int>)m.CreateDelegate(
                typeof(Predicate<int>), zeroThreshold);

            Console.WriteLine(greaterThanZero(42));
        }

        public static void CallMeRightBack(Predicate<int> userCallback)
        {
            bool result = userCallback(42);
            Console.WriteLine(result);
        }

        public static void TestForMajority(Predicate<int> userCallbacks)
        {
            int trueCount = 0;
            int falseCount = 0;
            foreach (Predicate<int> p in userCallbacks.GetInvocationList())
            {
                bool result = p(42);
                if (result)
                {
                    trueCount += 1;
                }
                else
                {
                    falseCount += 1;
                }
            }
            if (trueCount > falseCount)
            {
                Console.WriteLine("The majority returned true");
            }
            else if (falseCount > trueCount)
            {
                Console.WriteLine("The majority returned false");
            }
            else
            {
                Console.WriteLine("It's a tie");
            }
        }
    }
}