namespace ReflectionTypes
{
    public class PropertyAccessorAccessibility
    {
        public int Count
        {
            get;
            private set;
        }

        // This example shows something that doesn't compile, so the #if false
        // is here to prevent a compiler error.
#if false
        // Won't compile, but arguably should
        int Count
        {
            public get;
            private set;
        }
#endif
    }
}