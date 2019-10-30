using System;

namespace CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PluginInformationAttribute : Attribute
    {
        public PluginInformationAttribute(string name, string author)
        {
            Name = name;
            Author = author;
        }

        public string Name { get; }

        public string Author { get; }

        public string Description { get; set; }
    }
}