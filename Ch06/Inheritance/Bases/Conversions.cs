namespace Bases.InheritanceChain
{
    public class Conversions
    {
        public static void UseAsDerived(Base baseArg)
        {
            var d = (Derived)baseArg;

            // ... go on to do something with d
        }

        public static void MightUseAsDerived(Base b)
        {
            var d = b as Derived;

            if (d != null)
            {
                // ... go on to do something with d
            }
        }

        public static void UseIsOperator(Base b)
        {
            if (!(b is WeirdType))
            {
                // ... do the processing that everything except WeirdType requires
            }
        }

        private class WeirdType : Base { }
    }
}
