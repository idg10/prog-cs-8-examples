using System.Threading;

namespace Synchronization
{
    class UsingCompareExchange
    {
        static int InterlockedIncrement(ref int target)
        {
            int current, newValue;
            do
            {
                current = target;
                newValue = current + 1;
            }
            while (Interlocked.CompareExchange(ref target, newValue, current)
                    != current);
            return newValue;
        }
    }
}
