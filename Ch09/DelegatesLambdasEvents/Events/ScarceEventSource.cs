using System;
using System.Collections.Generic;

namespace Events
{
    public class ScarceEventSource
    {
        // One dictionary shared by all instances of this class,
        // tracking all handlers for all events.
        // Beware of memory leaks - this code is for illustration only.
        private static readonly
         Dictionary<(ScarceEventSource, object), EventHandler> _eventHandlers
          = new Dictionary<(ScarceEventSource, object), EventHandler>();

        // Objects used as keys to identify particular events in the dictionary.
        private static readonly object EventOneId = new object();
        private static readonly object EventTwoId = new object();


        public event EventHandler EventOne
        {
            add
            {
                AddEvent(EventOneId, value);
            }
            remove
            {
                RemoveEvent(EventOneId, value);
            }
        }

        public event EventHandler EventTwo
        {
            add
            {
                AddEvent(EventTwoId, value);
            }
            remove
            {
                RemoveEvent(EventTwoId, value);
            }
        }

        public void RaiseBoth()
        {
            RaiseEvent(EventOneId, EventArgs.Empty);
            RaiseEvent(EventTwoId, EventArgs.Empty);
        }

        private (ScarceEventSource, object) MakeKey(object eventId) => (this, eventId);

        private void AddEvent(object eventId, EventHandler handler)
        {
            var key = MakeKey(eventId);
            _eventHandlers.TryGetValue(key, out EventHandler entry);
            entry += handler;
            _eventHandlers[key] = entry;
        }

        private void RemoveEvent(object eventId, EventHandler handler)
        {
            var key = MakeKey(eventId);
            EventHandler entry = _eventHandlers[key];
            entry -= handler;
            if (entry == null)
            {
                _eventHandlers.Remove(key);
            }
            else
            {
                _eventHandlers[key] = entry;
            }
        }

        private void RaiseEvent(object eventId, EventArgs e)
        {
            var key = MakeKey(eventId);
            if (_eventHandlers.TryGetValue(key, out EventHandler handler))
            {
                handler(this, e);
            }
        }
    }
}