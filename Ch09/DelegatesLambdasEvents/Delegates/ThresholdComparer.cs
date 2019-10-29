using System;

namespace Delegates
{
    public class ThresholdComparer
    {
        public int Threshold { get; set; }

        public bool IsGreaterThan(int value) => value > Threshold;

        public Predicate<int> GetIsGreaterThanPredicate() => IsGreaterThan;
    }
}