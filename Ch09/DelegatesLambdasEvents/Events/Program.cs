using System;

namespace Events
{
    class Program
    {
        static void Main()
        {
            var source = new Eventful();
            source.Announcement += m => Console.WriteLine("Announcement: " + m);
        }

        // This example shows how not to do something. To see the compiler error, change
        // the #if false to #if true
#if false
        public static void HowNotToRaiseAnEvent()
        {
            var source = new Eventful();
            source.Announcement("Will this work?"); // No, this will not even compile
        }
#endif

        // This example illustrates what a system-defined type looks like. Since .NET
        // defines this, we don't actually want to define it ourselves, hence the
        // #if false.
#if false
        public delegate void EventHandler(object sender, EventArgs e);
#endif
    }
}