using System;

namespace BasicCoding
{
    internal static class Patterns
    {
        internal static void TuplePatterns((int x, int y) p)
        {
            switch (p)
            {
                case (0, 0):
                    Console.WriteLine("How original");
                    break;

                case (0, 1):
                case (1, 0):
                    Console.WriteLine("What an absolute unit");
                    break;

                case (1, 1):
                    Console.WriteLine("Be there and be square");
                    break;
            }
        }

        internal static void TypePatterns(object o)
        {
            switch (o)
            {
                case string s:
                    Console.WriteLine($"A piece of string is {s.Length} long");
                    break;

                case int i:
                    Console.WriteLine($"That's numberwang! {i}");
                    break;
            }
        }

        internal static void PositionalPatterns(object o)
        {
            switch (o)
            {
                case (0, int y):
                    Console.WriteLine($"This is on the X axis, at height {y}");
                    break;

                case (int x, int y):
                    Console.WriteLine($"I know where it's at: {x}, {y}");
                    break;

                case (int x, _):
                    Console.WriteLine($"At X: {x}. As for Y, who knows?");
                    break;

                case (var x, var y):
                    Console.WriteLine($"I know where it's at: {x}, {y}");
                    break;
            }
        }

        internal static void PropertyPatterns(object o)
        {
            switch (o)
            {
                case string { Length: 0 }:
                    Console.WriteLine("How long is a piece of string? Not very!");
                    break;
            }

            switch (o)
            {
                case string { Length: 0 } s:
                    Console.WriteLine($"How long is a piece of string? This long: {s.Length}");
                    break;
            }

            switch (o)
            {
                case string { Length: int length }:
                    Console.WriteLine($"How long is a piece of string? This long: {length}");
                    break;
            }
        }

        internal static void PatternsWithWhen(object o)
        {
            switch (o)
            {
                case (int w, int h) when w > h:
                    Console.WriteLine("Landscape");
                    break;
            }
        }

        internal static string NonExpressionPatterns(object shape)
        {
            switch (shape)
            {
                case (int w, int h) when w < h: return "Portrait";
                case (int w, int h) when w > h: return "Landscape";
                case (int _, int _): return "Square";
                default: return "Unknown";
            }
        }

        internal static string ExpressionPatterns(object shape)
        {
            return shape switch
            {
                (int w, int h) when w < h => "Portrait",
                (int w, int h) when w > h => "Landscape",
                (int _, int _) => "Square",
                _ => "Unknown"
            };
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example doesn't actually used its outputs")]
        internal static void IsExpression(object value)
        {
            bool isPoint = value is (int x, int y);
        }

        internal static void MoreIsExpressions(object value)
        {
            if (value is (int x, int y))
            {
                Console.WriteLine($"X: {x}, Y: {y}");
            }

            if (value is (int w, int h) && w < h)
            {
                Console.WriteLine($"(Portrait) Width: {w}, Height: {h}");
            }
        }
    }
}
