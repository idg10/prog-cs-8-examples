namespace Methods
{
    // Change to #if true to see compilation errors
#if false
    public class Referable
    {
        private int i;
        private int[] items = new int[10];

        public ref int FieldRef => ref i;

        public ref int GetArrayElementRef(int index) => ref items[index];

        public ref int GetBackSameRef(ref int arg) => ref arg;

        public ref int WillNotCompile()
        {
            int v = 42;
            return ref v;
        }

        public ref int WillAlsoNotCompile()
        {
            int i = 42;
            return ref GetBackSameRef(ref i);
        }

        public ref int WillCompile(ref int i)
        {
            return ref GetBackSameRef(ref i);
        }
    }
#endif
}
