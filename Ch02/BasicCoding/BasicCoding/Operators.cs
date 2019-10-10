using System;

namespace BasicCoding
{
    internal static class Operators
    {
        internal static void ConditionalAnd(string s)
        {
            if (s != null && s.Length > 10)
            {
                Console.WriteLine("A piece of string is over 10 chars long");
            }
        }

        internal static void ConditionalOperator(int x, int y)
        {
            int max = (x > y) ? x : y;

            Console.WriteLine($"The greater of these is {max}");
        }

        internal static void ConditionalEvaluation(string s)
        {
            int characterCount = s == null ? 0 : s.Length;

            Console.WriteLine($"You have supplied {characterCount} chars");
        }

        internal static void NullCoalescing(string s)
        {
            string neverNull = s ?? "";

            Console.WriteLine(neverNull.Length);
        }

        internal static void NullConditionalAndNullCoalescing(string s)
        {
            int characterCount = s?.Length ?? 0;

            Console.WriteLine($"You have supplied {characterCount} chars");
        }

        internal static void ConditionalOperatorAsArgument(bool gateOpen)
        {
            const double MaxVolume = 11;
            const double FadeDuration = 10;

            FadeVolume(gateOpen ? MaxVolume : 0.0, FadeDuration, FadeCurve.Linear);
        }

        internal static void LifeWithoutTheConditionalOperator(bool gateOpen)
        {
            const double MaxVolume = 11;
            const double FadeDuration = 10;

            double targetVolume;
            if (gateOpen)
            {
                targetVolume = MaxVolume;
            }
            else
            {
                targetVolume = 0.0;
            }
            FadeVolume(targetVolume, FadeDuration, FadeCurve.Linear);
        }

        private static void FadeVolume(double targetVolume, double fadeDuration, FadeCurve curve)
        {
            Console.WriteLine((targetVolume > 0.0 ? "Fade away" : "Not fade away") + $" for {fadeDuration}, using {curve}");
        }

        private static void Assignment(int x)
        {
            x = x + 1;

            Console.WriteLine(x);

            x += 1;

            Console.WriteLine(x);
        }

        private enum FadeCurve
        {
            Linear,
            Sinc,
            Log
        }
    }
}
