namespace Disposable
{
    class Program
    {
        static void Main()
        {
        }
    }

    // This is for illustration only - this interface is built into .NET so we do
    // not need to define it. That's why this is disabled with #if false
#if false
    public interface IDisposable
    {
        void Dispose();
    }
#endif
}
