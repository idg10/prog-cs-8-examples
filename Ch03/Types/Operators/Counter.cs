using System;
using System.Collections.Generic;
using System.Text;

namespace Operators
{
    public class Counter
    {
        private int _count;

        public int GetNextValue()
        {
            _count += 1;
            return _count;
        }

        public static Counter operator +(Counter x, Counter y)
        {
            return new Counter { _count = x._count + y._count };
        }

        public static Counter operator +(Counter x, int y)
        {
            return new Counter { _count = x._count + y };
        }

        public static Counter operator +(int x, Counter y)
        {
            return new Counter { _count = x + y._count };
        }

        public static explicit operator int(Counter value)
        {
            return value._count;
        }

        public static explicit operator Counter(int value)
        {
            return new Counter { _count = value };
        }
    }
}