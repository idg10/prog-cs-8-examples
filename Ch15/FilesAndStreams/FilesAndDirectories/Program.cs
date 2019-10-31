using System;
using System.IO;

namespace FilesAndDirectories
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = File.Create("foo.bar"))
            {
            }

            // Equivalent code without using File class
            using (var fs = new FileStream("foo.bar", FileMode.Create,
                                           FileAccess.ReadWrite, FileShare.None))
            {
            }

            foreach (string file in Directory.GetFiles(@"c:\users\ian\Pictures",
                                                       "*.jpg",
                                                       SearchOption.AllDirectories))
            {
                Console.WriteLine(file);
            }

            var fi = new FileInfo(@"c:\temp\log.txt");
            Console.WriteLine(
                $"{fi.FullName} ({fi.Length} bytes) last modified on {fi.LastWriteTime}");

            string appSettingsRoot =
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string myAppSettingsFolder =
                Path.Combine(appSettingsRoot, @"Endjin\FrobnicatorPro");
        }
    }

    // Members of FileStream for illustration purposes only. These are defined by .NET so
    // we don't need to define them ourselves.
#if false
public FileStream(string path, FileMode mode)
public FileStream(string path, FileMode mode, FileAccess access)
public FileStream(string path, FileMode mode, FileAccess access,
                  FileShare share)
public FileStream(string path, FileMode mode, FileAccess access,
                  FileShare share, int bufferSize);
public FileStream(string path, FileMode mode, FileAccess access,
                  FileShare share, int bufferSize, bool useAsync);
public FileStream(string path, FileMode mode, FileAccess access,
                  FileShare share, int bufferSize, FileOptions options);
#endif
}
