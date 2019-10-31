using System;
using System.Threading;

namespace ThreadAffinity
{
    public class Defer
    {
        private readonly Action _callback;
        private readonly ExecutionContext _context;

        public Defer(Action callback)
        {
            _callback = callback;
            _context = ExecutionContext.Capture();
        }

        public void Run()
        {
            ExecutionContext.Run(_context, (unusedStateArg) => _callback(), null);
        }
    }
}