using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionaries
{
    public class UserCache
    {
        private readonly Dictionary<string, UserInfo> _cachedUserInfo =
            new Dictionary<string, UserInfo>();

        public UserInfo GetInfo(string userHandle)
        {
            RemoveStaleCacheEntries();
            if (!_cachedUserInfo.TryGetValue(userHandle, out UserInfo info))
            {
                info = FetchUserInfo(userHandle);
                _cachedUserInfo.Add(userHandle, info);
            }
            return info;
        }

        private UserInfo FetchUserInfo(string userHandle)
        {
            // fetch info ...
            return new UserInfo();
        }

        private void RemoveStaleCacheEntries()
        {
            // application-specific logic deciding when to remove old entries ...
        }
    }

    public class UserInfo
    {
        // application-specific user information ...
    }
}
