using System;

namespace Delegates
{
    public class ExplicitInvoke
    {
        public static void CallMeRightBack(Predicate<int> userCallback)
        {
            bool result = userCallback.Invoke(42);
            Console.WriteLine(result);
        }
    }
}