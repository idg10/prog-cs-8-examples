namespace Indexers
{
    public class Indexed
    {
        public string this[int index]
        {
            get => index < 5 ? "Foo" : "bar";
        }
    }
}
