using System.Threading;

namespace Synchronization
{
    public class DecimalTotal
    {
        private decimal _total;

        private SpinLock _lock;

        public decimal Total
        {
            get
            {
                bool acquiredLock = false;
                try
                {
                    _lock.Enter(ref acquiredLock);
                    return _total;
                }
                finally
                {
                    if (acquiredLock)
                    {
                        _lock.Exit();
                    }
                }
            }
        }

        public void Add(decimal value)
        {
            bool acquiredLock = false;
            try
            {
                _lock.Enter(ref acquiredLock);
                _total += value;
            }
            finally
            {
                if (acquiredLock)
                {
                    _lock.Exit();
                }
            }
        }
    }
}