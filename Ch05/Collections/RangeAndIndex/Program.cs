using System;

namespace RangeAndIndex
{
    class Program
    {
        static void Main()
        {
            char[] letters = { 'a', 'b', 'c', 'd' };
            char lastLetter = letters[^1];

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
            // Gets 4th and 5th (but not, the 3rd, for reasons explained shortly)
            int[] theFourthTheFifth = numbers[3..5];

            Index first = 0;
            Index second = 1;
            Index third = 2;
            var fourth = new Index(3, fromEnd: false);

            Index antePenultimate = ^3;
            Index penultimate = ^2;
            Index last = ^1;
            Index directlyAfterTheLast = ^0;

            int lastOld = numbers[numbers.Length - 1];
            int lastNew = numbers[^1];

            int penultimateOld = numbers[numbers.Length - 2];
            int penultimateNew = numbers[^2];

            Range everything = 0..^0;
            Range alsoEverything = 0..;
            Range everythingAgain = ..^0;
            Range everythingOneMoreTime = ..;
            var yetAnotherWayToSayEverything = Range.All;

            Range firstThreeItems = 0..3;
            Range alsoFirstThreeItems = ..3;

            Range allButTheFirstThree = 3..^0;
            Range alsoAllButTheFirstThree = 3..;

            Range allButTheLastThree = 0..^3;
            Range alsoAllButTheLastThree = ..^3;

            Range lastThreeItems = ^3..^0;
            Range alsoLastThreeItems = ^3..;

            string t1 = "dysfunctional";
            string t2 = t1[3..6];
            Console.WriteLine($"Putting the {t2} in {t1}");

            Rangeable r1 = new Rangeable();
            Range r = 2..^2;

            Rangeable r2;

            r2 = r1[r];
            // is equivalent to
            int startIndex = r.Start.GetOffset(r1.Length);
            int endIndex = r.End.GetOffset(r1.Length);
            r2 = r1.Slice(startIndex, endIndex - startIndex);
        }

        public static void ArraySegmentSubrange()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
            ArraySegment<int> wholeArrayAsSegment = numbers;
            ArraySegment<int> theFourthTheFifth = wholeArrayAsSegment[3..5];
        }

        public static void SpanSubrange()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
            Span<int> wholeArrayAsSpan = numbers;
            Span<int> theFourthTheFifth = wholeArrayAsSpan[3..5];
            ReadOnlySpan<char> textSpan = "dysfunctional".AsSpan();
            ReadOnlySpan<char> such = textSpan[3..6];
        }
    }
}