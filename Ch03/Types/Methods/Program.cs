using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Methods
{
    class Program
    {
        static void Main()
        {
            int q = Divide(10, 3, out int r);

            Console.WriteLine(q);

            string text = "42";
            int value = int.TryParse(text, out int x) ? x : 0;
            Console.WriteLine(value);

            UseOutParam();
            DiscardOutParam();
            UseRefParam();
            UseInParam();

            string rose = null;
            ref string rosaIndica = ref rose;
            rosaIndica = "smell as sweet";
            Console.WriteLine($"A rose by any other name would {rose}");

            Blame("mischievous gnomes");
            Blame(problem: "everything");

            StringInterpolation();
            StringFormatting();

            GetAverageDistanceFrom((0, 0), new[] { (1.0, 0.0), (0.0, 3.0) });
            GetAverageDistanceFromWithExpressionBodiedMethod((0, 0), new[] { (1.0, 0.0), (0.0, 3.0) });
        }

        public static int Divide(int x, int y, out int remainder)
        {
            remainder = x % y;
            return x / y;
        }

        private static void UseOutParam()
        {
            int r, q;
            q = Divide(10, 3, out r);
            Console.WriteLine($"3: {q}, {r}");
            q = Divide(10, 4, out r);
            Console.WriteLine($"4: {q}, {r}");
        }

        private static void DiscardOutParam()
        {
            int q = Divide(10, 3, out _);

            Console.WriteLine(q);
        }

        private static void UseRefParam()
        {
            long x = 41;
            Interlocked.Increment(ref x);
            Console.WriteLine(x);
        }

        public static double GetArea(in Rect r) => r.Width * r.Height;

        private static void UseInParam()
        {
            var r = new Rect(10, 20, 100, 100);
            double area = GetArea(in r);
            double area2 = GetArea(r);
        }

        public static void Blame(string perpetrator = "the youth of today",
            string problem = "the downfall of society")
        {
            Console.WriteLine($"I blame {perpetrator} for {problem}.");
        }

        public static void UnclearArguments()
        {
            using Stream stream = new MemoryStream(Encoding.UTF8.GetBytes("Test"));
            using var r = new StreamReader(stream, Encoding.UTF8, true, 8192, false);
        }

        public static void ClearArguments()
        {
            using Stream stream = new MemoryStream(Encoding.UTF8.GetBytes("Test"));
            using var r = new StreamReader(stream, Encoding.UTF8,
                detectEncodingFromByteOrderMarks: true, bufferSize: 8192, leaveOpen: false);
        }

        public static void SelectiveArgumentNaming(string filepath)
        {
            using var w = new StreamWriter(filepath, append: true, Encoding.UTF8);
        }

        public static void StringInterpolation()
        {
            Console.WriteLine($"PI: {Math.PI}. Square root of 2: {Math.Sqrt(2)}");
            Console.WriteLine($"It is currently {DateTime.Now}");
            var r = new Random();
            Console.WriteLine(
                $"{r.Next(10)}, {r.Next(10)}, {r.Next(10)}, {r.Next(10)}");
        }

        public static void StringFormatting()
        {
            Console.WriteLine(string.Format(
                "PI: {0}. Square root of 2: {1}", Math.PI, Math.Sqrt(2)));
            Console.WriteLine(string.Format("It is currently {0}", DateTime.Now));
            var r = new Random();
            Console.WriteLine(string.Format(
                "{0}, {1}, {2}, {3}",
                r.Next(10), r.Next(10), r.Next(10), r.Next(10)));

            Console.WriteLine(string.Format(
                "{0}, {1}, {2}, {3}",
                new object[] { r.Next(10), r.Next(10), r.Next(10), r.Next(10) }));
        }

        /* This is for illustration only
        public static string Format(string format, params object[] args)
        */

        static double GetAverageDistanceFrom(
            (double X, double Y) referencePoint,
            (double X, double Y)[] points)
        {
            double total = 0;
            for (int i = 0; i < points.Length; ++i)
            {
                total += GetDistanceFromReference(points[i]);
            }
            return total / points.Length;

            double GetDistanceFromReference((double X, double Y) p)
            {
                return GetDistance(p, referencePoint);
            }

            static double GetDistance((double X, double Y) p1, (double X, double Y) p2)
            {
                double dx = p1.X - p2.X;
                double dy = p1.Y - p2.Y;
                return Math.Sqrt(dx * dx + dy * dy);
            }
        }

        static double GetAverageDistanceFromWithExpressionBodiedMethod(
            (double X, double Y) referencePoint,
            (double X, double Y)[] points)
        {
            double total = 0;
            for (int i = 0; i < points.Length; ++i)
            {
                total += GetDistanceFromReference(points[i]);
            }
            return total / points.Length;

            double GetDistanceFromReference((double X, double Y) p)
                => GetDistance(p, referencePoint);


            static double GetDistance((double X, double Y) p1, (double X, double Y) p2)
            {
                double dx = p1.X - p2.X;
                double dy = p1.Y - p2.Y;
                return Math.Sqrt(dx * dx + dy * dy);
            }
        }
    }
}
