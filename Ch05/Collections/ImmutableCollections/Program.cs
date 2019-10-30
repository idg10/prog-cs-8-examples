using System.Collections.Immutable;

namespace ImmutableCollections
{
    class Program
    {
        static void Main()
        {
            Create();
            CreateWithBuilder();
        }

        public static void Create()
        {
            IImmutableDictionary<int, string> d = ImmutableDictionary.Create<int, string>();
            d = d.Add(1, "One");
            d = d.Add(2, "Two");
            d = d.Add(3, "Three");

            System.Console.WriteLine(d[2]);
        }
    
        public static void CreateWithBuilder()
        {
            ImmutableDictionary<int, string>.Builder b =
                ImmutableDictionary.CreateBuilder<int, string>();
            b.Add(1, "One");
            b.Add(2, "Two");
            b.Add(3, "Three");
            IImmutableDictionary<int, string> d = b.ToImmutable();
        
            System.Console.WriteLine(d[2]);
        }
    }
}
