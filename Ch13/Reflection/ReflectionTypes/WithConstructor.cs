// Different namespace to match Example 3
namespace MyApp
{
    public class WithConstructor
    {
        public WithConstructor(string arg)
        {
            Arg = arg;
        }

        public string Arg { get; }
    }
}
