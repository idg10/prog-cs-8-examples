using System;
using System.Net;
using System.Threading.Tasks;

namespace Threading
{
    public static class TaskThreadPool
    {
        public static void DoWork()
        {
            Task.Run(() => MyThreadEntryPoint("https://oreilly.com/"));
        }

        private static void MyThreadEntryPoint(object arg)
        {
            string url = (string)arg;

            using (var w = new WebClient())
            {
                Console.WriteLine($"Downloading {url}");
                string page = w.DownloadString(url);
                Console.WriteLine($"Downloaded {url}, length {page.Length}");
            }
        }
    }
}