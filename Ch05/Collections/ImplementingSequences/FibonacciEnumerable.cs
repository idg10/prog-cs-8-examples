using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace ImplementingSequences
{
    public class FibonacciEnumerable :
        IEnumerable<BigInteger>, IEnumerator<BigInteger>
    {
        private BigInteger v1;
        private BigInteger v2;
        private bool first = true;

        public BigInteger Current => v1;

        public void Dispose() { }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (first)
            {
                v1 = 1;
                v2 = 1;
                first = false;
            }
            else
            {
                var tmp = v2;
                v2 = v1 + v2;
                v1 = tmp;
            }

            return true;
        }

        public void Reset()
        {
            first = true;
        }

        public IEnumerator<BigInteger> GetEnumerator() =>
            new FibonacciEnumerable();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}