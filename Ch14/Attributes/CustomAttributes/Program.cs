using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CustomAttributes
{
    class Program
    {
        static void Main()
        {
            ShowPluginInformation(Path.GetDirectoryName(typeof(Program).Assembly.Location));
            
            
            // Note: only works on .NET Framework. Change the project target framework to be .NET Framework
            // to try this.
            // ShowPluginInformationReflectionOnlyContext(new FileInfo(typeof(Program).Assembly.Location));
        }

        static void ShowPluginInformation(string pluginFolder)
        {
            var dir = new DirectoryInfo(pluginFolder);
            foreach (var file in dir.GetFiles("*.dll"))
            {
                Assembly pluginAssembly = Assembly.LoadFrom(file.FullName);
                var plugins =
                     from type in pluginAssembly.ExportedTypes
                     let info = type.GetCustomAttribute<PluginInformationAttribute>()
                     where info != null
                     select new { type, info };

                foreach (var plugin in plugins)
                {
                    Console.WriteLine($"Plugin type: {plugin.type.Name}");
                    Console.WriteLine(
                        $"Name: {plugin.info.Name}, written by {plugin.info.Author}");
                    Console.WriteLine($"Description: {plugin.info.Description}");
                }
            }
        }

        static void ShowPluginInformationReflectionOnlyContext(FileInfo file)
        {
            Type pluginAttributeType = typeof(PluginInformationAttribute);

            Assembly pluginAssembly = Assembly.ReflectionOnlyLoadFrom(file.FullName);
            var plugins =
                 from type in pluginAssembly.ExportedTypes
                 let info = type.GetCustomAttributesData().SingleOrDefault(
                                attrData => attrData.AttributeType.FullName == pluginAttributeType.FullName)
                 where info != null
                 let description = info.NamedArguments
                                       .SingleOrDefault(a => a.MemberName == "Description")
                 select new
                 {
                     type,
                     Name = (string)info.ConstructorArguments[0].Value,
                     Author = (string)info.ConstructorArguments[1].Value,
                     Description =
                         description == null ? null : description.TypedValue.Value
                 };

            foreach (var plugin in plugins)
            {
                Console.WriteLine($"Plugin type: {plugin.type.Name}");
                Console.WriteLine($"Name: {plugin.Name}, written by {plugin.Author}");
                Console.WriteLine($"Description: {plugin.Description}");
            }
        }
    }

    // .NET defines this type. The book shows it only for illustration, hence the
    // #if false here.
#if false
    public interface ICustomAttributeProvider
    {
        object[] GetCustomAttributes(bool inherit);
        object[] GetCustomAttributes(Type attributeType, bool inherit);
        bool IsDefined(Type attributeType, bool inherit);
    }
#endif
}
