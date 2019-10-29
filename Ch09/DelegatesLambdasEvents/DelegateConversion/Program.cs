using System;

namespace DelegateConversion
{
    class Program
    {
        public static bool IsLongString(object o)
        {
            return o is string s && s.Length > 20;
        }

        static void Main(string[] args)
        {
            Predicate<object> po = IsLongString;
            Predicate<string> ps = po;
            Console.WriteLine(ps("Too short"));
        }

        // This example shows an approach that will not work. Change the
        // #if false to #if true to see the compiler error.
#if false
        public static void IllegalConversion()
        {
            Predicate<string> pred = IsLongString;
            Func<string, bool> f = pred;  // Will fail with compiler error
        }
#endif

        public static void DelegateToDelegate()
        {
            Predicate<string> pred = IsLongString;
            var pred2 = new Func<string, bool>(pred); // Less efficient than
                                                      // a direct reference

            Console.WriteLine(pred2("x"));
            Console.WriteLine(pred2(new string('x', 100)));
        }

        public static void DelegateToDelegateExplicit()
        {
            Predicate<string> pred = IsLongString;
            var pred2 = new Func<string, bool>(pred.Invoke);

            Console.WriteLine(pred2("x"));
            Console.WriteLine(pred2(new string('x', 100)));
        }

        public static void NewDelegateForcurrentTarget()
        {
            Predicate<string> pred = IsLongString;
            var pred2 = (Func<string, bool>)pred.Method.CreateDelegate(
              typeof(Func<string, bool>), pred.Target);

            Console.WriteLine(pred2("x"));
            Console.WriteLine(pred2(new string('x', 100)));
        }

        public static TResult DuplicateDelegateAs<TResult>(MulticastDelegate source)
            where TResult : Delegate
        {
            Delegate result = null;
            foreach (Delegate sourceItem in source.GetInvocationList())
            {
                var copy = sourceItem.Method.CreateDelegate(
                  typeof(TResult), sourceItem.Target);
                result = Delegate.Combine(result, copy);
            }

            return (TResult)(object)result;
        }
    }
}
