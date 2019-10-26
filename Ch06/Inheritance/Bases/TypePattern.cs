namespace Bases.InheritanceChain
{
    public class TypePattern
    {
        public static void MightUseAsDerived(Base b)
        {
            if (b is Derived d)
            {
                // ... go on to do something with d
            }
        }
    }
}
