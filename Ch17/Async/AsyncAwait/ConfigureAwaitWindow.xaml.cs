using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncAwait
{
    /// <summary>
    /// Interaction logic for ConfigureAwaitWindow.xaml
    /// </summary>
    public partial class ConfigureAwaitWindow : Window
    {
        private readonly IHttpClientFactory clientFactory;

        public ConfigureAwaitWindow()
        {
            InitializeComponent();

            var services = new ServiceCollection();
            services.AddHttpClient();
            this.clientFactory = services.BuildServiceProvider().GetRequiredService<IHttpClientFactory>();
        }

        private async void OnFetchButtonClick(object sender, RoutedEventArgs e)
        {
            using (HttpClient w = this.clientFactory.CreateClient())
            using (Stream f = File.Create(fileTextBox.Text))
            {
                Task<Stream> getStreamTask = w.GetStreamAsync(urlTextBox.Text);
                Stream getStream = await getStreamTask.ConfigureAwait(false);

                Task copyTask = getStream.CopyToAsync(f);
                await copyTask.ConfigureAwait(false);
            }
        }
    }
}