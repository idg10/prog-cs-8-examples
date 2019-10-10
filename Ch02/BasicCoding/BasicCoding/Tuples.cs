using System;

namespace BasicCoding
{
    internal static class Tuples
    {
        internal static void CreatingAndUsingTuples()
        {
            (int X, int Y) point = (10, 5);
            Console.WriteLine($"X: {point.X}, Y: {point.Y}");
        }

        internal static void NamingTupleMembersInInitializer()
        {
            var point = (X: 10, Y: 5);
            Console.WriteLine($"X: {point.X}, Y: {point.Y}");
        }

        internal static void InferingTupleMemberNamesFromVariables()
        {
            int x = 10, y = 5;
            var point = (x, y);
            Console.WriteLine($"X: {point.x}, Y: {point.y}");
        }

        internal static void DefaultTupleMemberNames()
        {
            (int, int) point = (10, 5);
            Console.WriteLine($"X: {point.Item1}, Y: {point.Item2}");
        }

        internal static void TupleStructuralEquivalence()
        {
            (int X, int Y) point = (46, 3);
            (int Width, int Height) dimensions = point;
            (int Age, int NumberOfChildren) person = point;

            Console.WriteLine(dimensions);
            Console.WriteLine(person);
        }

        internal static void ConstructingAndDeconstructingTuples()
        {
            (int X, int Y) point1 = (40, 6);
            (int X, int Y) point2 = (12, 34);

            (int x, int y) = point1;
            Console.WriteLine($"1: {x}, {y}");
            (x, y) = point2;
            Console.WriteLine($"2: {x}, {y}");
        }
    }
}
