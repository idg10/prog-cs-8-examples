using System;
using System.Net.Mail;
using System.Threading;

namespace Synchronization
{
    static class EventObjects
    {
        static void LogFailure(string message, string mailServer)
        {
            var email = new SmtpClient(mailServer);

            using (var emailSent = new ManualResetEvent(false))
            {
                object sync = new object();
                bool tooLate = false; // Prevent call to Set after a timeout
                email.SendCompleted += (s, e) =>
                { lock (sync) { if (!tooLate) { emailSent.Set(); } } };
                email.SendAsync("logger@example.com", "sysadmin@example.com",
                    "Failure Report", "An error occurred: " + message, null);

                LogPersistently(message);

                if (!emailSent.WaitOne(TimeSpan.FromMinutes(1)))
                {
                    LogPersistently("Timeout sending email for error: " + message);
                }

                lock (sync)
                {
                    tooLate = true;
                }
            }
        }

        private static void LogPersistently(string message)
        {
            // It's only a demo.
        }
    }
}
