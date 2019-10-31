using System.ComponentModel;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Tpl
{
    public static class SmtpAsyncExtensions
    {
        public static Task SendTaskAsync(this SmtpClient mailClient, string from,
                                    string recipients, string subject, string body)
        {
            var tcs = new TaskCompletionSource<object>();

            void CompletionHandler(object s, AsyncCompletedEventArgs e)
            {
                mailClient.SendCompleted -= CompletionHandler;
                if (e.Cancelled)
                {
                    tcs.SetCanceled();
                }
                else if (e.Error != null)
                {
                    tcs.SetException(e.Error);
                }
                else
                {
                    tcs.SetResult(null);
                }
            };

            mailClient.SendCompleted += CompletionHandler;
            mailClient.SendAsync(from, recipients, subject, body, null);

            return tcs.Task;
        }
    }
}