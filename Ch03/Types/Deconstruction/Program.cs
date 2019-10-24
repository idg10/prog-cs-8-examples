using System;

namespace Deconstruction
{
    class Program
    {
        static void Main()
        {
            var s = new Size(10, 20);
            Console.WriteLine(DiagonalLength(s));
            Console.WriteLine(DescribeSize(s));
            Console.WriteLine(Describe(s));
        }

        static double DiagonalLength(Size s)
        {
            (double w, double h) = s;
            return Math.Sqrt(w * w + h * h);
        }

        static string DescribeSize(Size s) => s switch
        {
            (0, 0) => "Empty",
            (0, _) => "Extremely narrow",
            (double w, 0) => $"Extremely short, and this wide: {w}",
            _ => "Normal"
        };

        static string Describe(object o) => o switch
        {
            Size(0, 0) => "Empty",
            Size(0, _) => "Extremely narrow",
            Size(double w, 0) => $"Extremely short, and this wide: {w}",
            Size _ => "Normal shape",
            _ => "Not a shape"
        };
    }
}
