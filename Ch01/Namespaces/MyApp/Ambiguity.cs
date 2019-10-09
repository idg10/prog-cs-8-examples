using System.IO;
using System.Windows.Shapes;
using IoPath = System.IO.Path;
using WpfPath = System.Windows.Shapes.Path;

namespace MyApp
{
    public class Ambiguity
    {
        public static Shape LoadPathFromFile(string folder, string name)
        {
            string path = IoPath.Combine(folder, name);
            string pathData = File.ReadAllText(path);
            return new WpfPath { Data = System.Windows.Media.Geometry.Parse(pathData) };
        }
    }
}
