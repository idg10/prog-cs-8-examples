using System;

namespace AnonymousFunctions
{
    public static class LambdaSyntax
    {
        public static int GetIndexOfFirstNonEmptyBin(int[] bins)
        {
            return Array.FindIndex(
                bins,
                value => value > 0
            );
        }

        public static void Variations()
        {
            Predicate<int> p1 = value => value > 0;
            Predicate<int> p2 = (value) => value > 0;
            Predicate<int> p3 = (int value) => value > 0;
            Predicate<int> p4 = value => { return value > 0; };
            Predicate<int> p5 = (value) => { return value > 0; };
            Predicate<int> p6 = (int value) => { return value > 0; };

            foreach (Predicate<int> p in new[] { p1, p2, p3, p4, p5, p6 })
            {
                Console.WriteLine(p(10));
                Console.WriteLine(p(-10));
                Console.WriteLine();
            }
        }

        public static void ZeroArgumentForm()
        {
            Func<bool> isAfternoon = () => DateTime.Now.Hour >= 12;

            Console.WriteLine(isAfternoon());
        }
    }
}
