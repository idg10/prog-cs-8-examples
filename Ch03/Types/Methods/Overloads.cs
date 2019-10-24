using System;

namespace Methods
{
    public static class Overloads
    {
        public static void Blame(string perpetrator, string problem)
        {
            Console.WriteLine($"I blame {perpetrator} for {problem}.");
        }

        public static void Blame(string perpetrator)
        {
            Blame(perpetrator, "the downfall of society");
        }

        public static void Blame()
        {
            Blame("the youth of today", "the downfall of society");
        }
    }
}
