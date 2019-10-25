namespace GenericTypes
{
    public class NamedContainer<T>
    {
        public NamedContainer(T item, string name)
        {
            Item = item;
            Name = name;
        }

        public T Item { get; }
        public string Name { get; }
    }
}