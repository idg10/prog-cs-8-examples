using System;
using System.Threading;

namespace Threading
{
    class Notifier
    {
        private readonly ThreadLocal<bool> _isCallbackInProgress =
            new ThreadLocal<bool>();

        private readonly Action _callback;

        public Notifier(Action callback)
        {
            _callback = callback;
        }

        public void Notify()
        {
            if (_isCallbackInProgress.Value)
            {
                throw new InvalidOperationException(
                    "Notification already in progress on this thread");
            }

            try
            {
                _isCallbackInProgress.Value = true;
                _callback();
            }
            finally
            {
                _isCallbackInProgress.Value = false;
            }
        }
    }
}