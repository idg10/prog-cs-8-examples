using Newtonsoft.Json.Linq;
using System;

namespace PlugInInterface
{
    public interface IPlugIn
    {
        string Foo(JObject o);
    }
}
