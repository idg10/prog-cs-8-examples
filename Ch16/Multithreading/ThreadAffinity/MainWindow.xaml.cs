using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ThreadAffinity
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

        private void findButton_Click(object sender, RoutedEventArgs e)
        {
            SynchronizationContext uiContext = SynchronizationContext.Current;

            Task.Run(() =>
            {
                string pictures =
                    Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                var folder = new DirectoryInfo(pictures);
                FileInfo[] allFiles =
                    folder.GetFiles("*.jpg", SearchOption.AllDirectories);
                FileInfo largest =
                    allFiles.OrderByDescending(f => f.Length).FirstOrDefault();

                uiContext.Post(_ =>
                {
                    long sizeMB = largest.Length / (1024 * 1024);
                    outputTextBox.Text =
                        $"Largest file ({sizeMB}MB) is {largest.FullName}";
                },
                null);
            });
        }
    }
}