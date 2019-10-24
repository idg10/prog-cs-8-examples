namespace Properties.Mutable
{
    using System.Windows;

    public class UseItem
    {

        // Change to #if true to see the compiler error this produces.
#if false
        public static void TryAndFailToModifySubproperty()
        {
            var item = new Item();
            item.Location.X = 123;  // Will not compile
        }
#endif

        public static void CompilesButObviouslyNotAGoodIdea()
        {
            var item = new Item();
            Point location = item.Location;
            location.X = 123;
        }
    }
}
