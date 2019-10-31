using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Text
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var fw = new StreamWriter(@"c:\temp\out.txt"))
            {
                fw.WriteLine($"Writing to a file at {DateTime.Now}");
            }

            string xmlContent =
                "<message><text>Hello</text><recipient>world</recipient></message>";
            var xmlReader = XmlReader.Create(new StringReader(xmlContent));
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Text)
                {
                    Console.WriteLine(xmlReader.Value);
                }
            }

            using (var sw = new StreamWriter("Text.txt", false,
                                 Encoding.GetEncoding(1252)))
            {
                sw.Write("£100");
            }
        }
    }

    // Members of StreamReader for illustration purposes only. These are defined by .NET so
    // we don't need to define them ourselves.
#if false
    public virtual int Read(char[] buffer, int index, int count) { ... }
    public virtual int ReadBlock(char[] buffer, int index, int count) { ... }
#endif
}