using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace TplSchedulers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static readonly HttpClient w = new HttpClient();
        private readonly TaskScheduler _uiScheduler =
            TaskScheduler.FromCurrentSynchronizationContext();

        private void FetchButtonClicked(object sender, RoutedEventArgs e)
        {
            string url = "https://endjin.com/";
            Task<string> webGetTask = w.GetStringAsync(url);

            webGetTask.ContinueWith(t =>
            {
                string webContent = t.Result;
                outputTextBox.Text = webContent;
            },
            _uiScheduler);

        }
    }
}