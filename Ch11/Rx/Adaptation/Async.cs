using System;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace Adaptation
{
    public static class Async
    {
        public static class FetchOnce
        {
            public static IObservable<string> GetWebPageAsObservable(
                Uri pageUrl, IHttpClientFactory cf)
            {
                HttpClient web = cf.CreateClient();
                Task<string> getPageTask = web.GetStringAsync(pageUrl);
                return getPageTask.ToObservable();
            }
        }

        public static class FetchPerSubscriber
        {
            public static IObservable<string> GetWebPageAsObservable(
                Uri pageUrl, IHttpClientFactory cf)
            {
                return Observable.FromAsync(() =>
                {
                    HttpClient web = cf.CreateClient();
                    return web.GetStringAsync(pageUrl);
                });
            }
        }
    }
}