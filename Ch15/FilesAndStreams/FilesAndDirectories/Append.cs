using System.IO;

namespace FilesAndDirectories
{
    class Append
    {
        class WithStreamWriter
        {
            static void Log(string message)
            {
                using (var sw = new StreamWriter(@"c:\temp\log.txt", true))
                {
                    sw.WriteLine(message);
                }
            }
        }

        class WithFileAppendText
        {
            static void Log(string message)
            {
                using (StreamWriter sw = File.AppendText(@"c:\temp\log.txt"))
                {
                    sw.WriteLine(message);
                }
            }
        }

        class WithFileAppendAllText
        {
            static void Log(string message)
            {
                File.AppendAllText(@"c:\temp\log.txt", message);
            }
        }

        class WithFileAppendAllLines
        {
            static void Log(string message)
            {
                File.AppendAllLines(@"c:\temp\log.txt", new[] { message });
            }
        }
    }
}