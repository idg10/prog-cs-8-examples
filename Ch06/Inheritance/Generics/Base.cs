using System.Collections.Generic;

namespace Generics
{
    public class Base
    {
        public static void UseBase(Base b)
        {
        }

        public static void AllYourBase(IEnumerable<Base> bases)
        {
        }

        public static void PassingIEnumerable()
        {
            IEnumerable<Derived> derivedItems =
                new Derived[] { new Derived(), new Derived() };
            AllYourBase(derivedItems);
        }

        public static void AddBase(ICollection<Base> bases)
        {
            bases.Add(new Base());
        }

        // Change to #if true to see compiler error
#if false
        public void IllegalAddBase()
        {
            ICollection<Derived> derivedList = new List<Derived>();
            AddBase(derivedList);  // Will not compile
        }
#endif

        public static void UseBaseArray(Base[] bases)
        {
            bases[0] = new Base();
        }

        public static void PassDerivedElementTypeArray()
        {
            Derived[] derivedBases = { new Derived(), new Derived() };
            UseBaseArray(derivedBases);
        }
    }
}
