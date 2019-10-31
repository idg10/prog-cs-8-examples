using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace AsyncAwait
{
    /// <summary>
    /// Interaction logic for LoopWindow.xaml
    /// </summary>
    public partial class LoopWindow : Window
    {
        private readonly IHttpClientFactory clientFactory;

        public LoopWindow()
        {
            InitializeComponent();

            var services = new ServiceCollection();
            services.AddHttpClient();
            this.clientFactory = services.BuildServiceProvider().GetRequiredService<IHttpClientFactory>();
        }

        private void fetchButton_Click(object sender, RoutedEventArgs e)
        {
            FetchAndShowBody(urlTextBox.Text, this.clientFactory);
        }

        // Example 11 shows this alternative
#if false
        private async Task FetchAndShowBody(string url, IHttpClientFactory cf)
#endif
        private async void FetchAndShowBody(string url, IHttpClientFactory cf)
        {
            using (HttpClient w = cf.CreateClient())
            {
                Stream body = await w.GetStreamAsync(url);
                using (var bodyTextReader = new StreamReader(body))
                {
                    while (!bodyTextReader.EndOfStream)
                    {
                        string line = await bodyTextReader.ReadLineAsync();
                        bodyTextBox.AppendText(line);
                        bodyTextBox.AppendText(Environment.NewLine);
                        await Task.Delay(TimeSpan.FromMilliseconds(10));
                    }
                }
            }
        }

        private void IncompleteOldSchoolFetchAndShowBody(
            string url, IHttpClientFactory cf)
        {
            HttpClient w = cf.CreateClient();
            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            w.GetStreamAsync(url).ContinueWith(getStreamTask =>
            {
                Stream body = getStreamTask.Result;
                var bodyTextReader = new StreamReader(body);

                StartNextIteration();

                void StartNextIteration()
                {
                    if (!bodyTextReader.EndOfStream)
                    {
                        bodyTextReader.ReadLineAsync().ContinueWith(readLineTask =>
                        {
                            string line = readLineTask.Result;

                            bodyTextBox.AppendText(line);
                            bodyTextBox.AppendText(Environment.NewLine);

                            Task.Delay(TimeSpan.FromMilliseconds(10))
                                .ContinueWith(
                                    _ => StartNextIteration(), uiScheduler);
                        },
                        uiScheduler);
                    }
                };
            },
                uiScheduler);
        }

        public static async Task<string> GetServerHeader(
            string url, IHttpClientFactory cf)
        {
            using (HttpClient w = cf.CreateClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Head, url);
                HttpResponseMessage response = await w.SendAsync(
                    request, HttpCompletionOption.ResponseHeadersRead);

                string result = null;
                IEnumerable<string> values;
                if (response.Headers.TryGetValues("Server", out values))
                {
                    result = values.FirstOrDefault();
                }
                return result;
            }
        }
    }
}