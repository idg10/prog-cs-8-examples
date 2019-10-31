using System.Collections.Generic;
using System.Threading;

namespace Synchronization
{
    public class MessageQueue<T>
    {
        private readonly object _sync = new object();

        private readonly Queue<T> _queue = new Queue<T>();

        public void Post(T message)
        {
            lock (_sync)
            {
                bool wasEmpty = _queue.Count == 0;
                _queue.Enqueue(message);
                if (wasEmpty)
                {
                    Monitor.Pulse(_sync);
                }
            }
        }

        public T Get()
        {
            lock (_sync)
            {
                while (_queue.Count == 0)
                {
                    Monitor.Wait(_sync);
                }
                return _queue.Dequeue();
            }
        }
    }
}