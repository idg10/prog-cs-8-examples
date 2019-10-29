using System;

namespace Events
{
    public class Eventful
    {
        public event Action<string> Announcement;

        public void Announce(string message)
        {
            Announcement?.Invoke(message);
        }
    }
}