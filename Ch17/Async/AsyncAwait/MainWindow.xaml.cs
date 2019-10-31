using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace AsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IHttpClientFactory clientFactory;

        public MainWindow()
        {
            InitializeComponent();

            var services = new ServiceCollection();
            services.AddHttpClient();
            this.clientFactory = services.BuildServiceProvider().GetRequiredService<IHttpClientFactory>();

            okButton.Click += async (s, e) =>
            {
                using (HttpClient w = this.clientFactory.CreateClient())
                {
                    infoTextBlock.Text = await w.GetStringAsync(uriTextBox.Text);
                }
            };
        }

        private void fetchHeadersButton_Click(object sender, RoutedEventArgs e)
        {
            FetchAndShowHeaders("https://endjin.com/", this.clientFactory);
            Debug.WriteLine("Method returned");
        }

        // Note: as you'll see later, async methods usually should not be void
        private async void FetchAndShowHeaders(string url, IHttpClientFactory cf)
        {
            using (HttpClient w = cf.CreateClient())
            {
                var req = new HttpRequestMessage(HttpMethod.Head, url);
                HttpResponseMessage response =
                    await w.SendAsync(req, HttpCompletionOption.ResponseHeadersRead);

                headerListTextBox.Text = response.Headers.ToString();
            }
        }

        private void OldSchoolFetchHeaders(string url, IHttpClientFactory cf)
        {
            HttpClient w = cf.CreateClient();
            var req = new HttpRequestMessage(HttpMethod.Head, url);

            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            w.SendAsync(req, HttpCompletionOption.ResponseHeadersRead)
                .ContinueWith(sendTask =>
                {
                    try
                    {
                        HttpResponseMessage response = sendTask.Result;
                        headerListTextBox.Text = response.Headers.ToString();
                    }
                    finally
                    {
                        w.Dispose();
                    }
                },
                uiScheduler);
        }
    }
}