using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Tpl
{
    class Program
    {
        static async Task Main()
        {
            var w = new HttpClient();
            string url = "https://endjin.com/";
            Task<string> webGetTask = w.GetStringAsync(url);

            string pageContent = await webGetTask;

#pragma warning disable CS4014 // The example doesn't do anything with the task returned, but the compiler doesn't like us doing that in an async method. Normally in an async method we just await instead of using ContinueWith
            webGetTask.ContinueWith(t =>
            {
                string webContent = t.Result;
                Console.WriteLine("Web page length: " + webContent.Length);
            });
#pragma warning restore CS4014
        }

        private static void ShowContinuations()
        {
            Task op = Task.Run(DoSomething);
            var cs = new CancellationTokenSource();
            Task onDone = op.ContinueWith(
                _ => Console.WriteLine("Never runs"),
                cs.Token);
            Task andAnotherThing = onDone.ContinueWith(
                _ => Console.WriteLine("Continuation's continuation"));
            cs.Cancel();
        }

        static void DoSomething()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Initial task finishing");
        }
    }

    // This example is illustrative and is not meant to compile, hence the #if false.
#if false
public virtual IAsyncResult BeginWrite(byte[] buffer, int offset, int count,
    AsyncCallback callback, object state) ...
public virtual void EndWrite(IAsyncResult asyncResult) ...

public abstract void Write(byte[] buffer, int offset, int count) ...
#endif
}