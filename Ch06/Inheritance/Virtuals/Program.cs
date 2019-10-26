using Library;

namespace Virtuals
{
    class Program
    {
        static void Main()
        {
            var d = new CustomerDerived();
            LibraryBase b = d;

            d.Start();
            b.Start();
        }

        public static void CallVirtualMethod(BaseWithVirtual o)
        {
            o.ShowMessage();
        }

        public static void ExploitingVirtualMethods()
        {
            CallVirtualMethod(new BaseWithVirtual());
            CallVirtualMethod(new DeriveWithoutOverride());
            CallVirtualMethod(new DeriveAndOverride());
        }
    }

    // For illustration only - this type is define by .NET so we don't
    // need to define it ourselves. The book just shows it as an example.
#if false
    public interface ISet<T> : ICollection<T>
    {
        new bool Add(T item);
        // ... other members omitted for clarity
    }
#endif
}
