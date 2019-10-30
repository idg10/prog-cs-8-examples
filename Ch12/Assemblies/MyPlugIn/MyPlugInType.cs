using Newtonsoft.Json.Linq;
using System;
using PlugInInterface;

namespace MyPlugIn
{
    public class MyPlugInType : IPlugIn
    {
        public string Foo(JObject o)
        {
            // We're built against v9.0.1 of Json.NET, so you might expect
            // this to show that, but because of the plug-in host's assembly
            // resolver, we get a unified version

            Console.WriteLine(o.GetType().Assembly.FullName);

            return "";
        }
    }
}
