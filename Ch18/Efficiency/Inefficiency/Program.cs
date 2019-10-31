using System;

namespace Inefficiency
{
    class Program
    {
        static void Main()
        {
            var uri = new Uri("http://example.com/books/1323?edition=6&format=pdf");
            Console.WriteLine(uri.Scheme);
            Console.WriteLine(uri.Host);
            Console.WriteLine(uri.AbsolutePath);
            Console.WriteLine(uri.Query);


            string uriString = "http://example.com/books/1323?edition=6&format=pdf";
            int id = int.Parse(uriString.Substring(25, 4));

            Console.WriteLine(id);
        }
    }
}