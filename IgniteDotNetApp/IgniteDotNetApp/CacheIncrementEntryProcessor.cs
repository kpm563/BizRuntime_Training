using System;
using System.Collections.Generic;
using System.Text;
using Apache.Ignite.Core.Cache;

namespace IgniteDotNetApp
{
    class CacheIncrementEntryProcessor:ICacheEntryProcessor<int, int,int, object>
    {
        public object Process(IMutableCacheEntry<int, int> entry, int arg)
        {
            //throw new NotImplementedException();
            entry.Value += arg;

            return null;
        }
    }
}
