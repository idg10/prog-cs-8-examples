using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AsyncEnum
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            await foreach (string line in ReadLinesAsync(args[0]))
            {
                Console.WriteLine(line);
            }
        }

        private static async IAsyncEnumerable<string> ReadLinesAsync(string path)
        {
            using (var bodyTextReader = new StreamReader(path))
            {
                while (!bodyTextReader.EndOfStream)
                {
                    string line = await bodyTextReader.ReadLineAsync();
                    yield return line;
                }
            }
        }
    }
}


// These examples illustrate features that are built into .NET. We don't
// want to define it ourselves, hence the #if false
#if false
    bool MoveNext();


public interface IAsyncEnumerable<out T>
{
    IAsyncEnumerator<T> GetAsyncEnumerator(
        CancellationToken cancellationToken = default);
}

public interface IAsyncEnumerator<out T> : IAsyncDisposable
{
    T Current { get; }

    ValueTask<bool> MoveNextAsync();
}
#endif
