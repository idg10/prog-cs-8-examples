using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Adaptation
{
    class Program
    {
        static void Main()
        {
            var services = new ServiceCollection();
            services.AddHttpClient();
            using ServiceProvider sp = services.BuildServiceProvider();

            IHttpClientFactory cf = sp.GetRequiredService<IHttpClientFactory>();
            IObservable<string> pageContentObservable = Async.FetchOnce.GetWebPageAsObservable(new Uri("https://endjin.com"), cf);

            using IDisposable sub = pageContentObservable.Subscribe(Console.WriteLine);

            Console.ReadKey();
        }
    }
}