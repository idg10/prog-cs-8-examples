using System;

namespace Delegates
{
    public static class ConditionalInvoke
    {
        public static void CallMeMaybe(Action<int> userCallback)
        {
            userCallback?.Invoke(42);
        }
    }
}