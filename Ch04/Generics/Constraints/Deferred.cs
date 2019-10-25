namespace Constraints
{
    // For illustration only. Consider using Lazy<T> in a real program.
    public static class Deferred<T>
        where T : new()
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
                return _instance;
            }
        }
    }
}