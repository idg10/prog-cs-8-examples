using System.Collections.Generic;

namespace Dictionaries
{
    public class AnotherCache
    {
        private readonly Dictionary<string, UserInfo> _cachedUserInfo =
            new Dictionary<string, UserInfo>();

        public void UseCache(string userHandle)
        {
            UserInfo info = _cachedUserInfo[userHandle];
        }
    }
}