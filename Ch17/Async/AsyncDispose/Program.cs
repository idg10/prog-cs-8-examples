using System;
using System.IO;
using System.Threading.Tasks;

namespace AsyncDispose
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await using (var w = new DiagnosticWriter(@"c:\temp\log.txt"))
            {
                await w.LogAsync("Test");
            }
        }
    }

    class DiagnosticWriter : IAsyncDisposable
    {
        private StreamWriter fs;

        public DiagnosticWriter(string path)
        {
            fs = new StreamWriter(path);
        }

        public Task LogAsync(string message) => fs.WriteLineAsync(message);

        public async ValueTask DisposeAsync()
        {
            if (fs != null)
            {
                await fs.FlushAsync();
                fs = null;
            }
        }
    }
}