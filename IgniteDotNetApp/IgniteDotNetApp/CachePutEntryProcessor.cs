using System;
using System.Collections.Generic;
using System.Text;
using Apache.Ignite.Core.Cache;

namespace IgniteDotNetApp
{
    class CachePutEntryProcessor:ICacheEntryProcessor<int, int, int, object>
    {
        public object Process(IMutableCacheEntry<int, int> entry, int arg)
        {
            //throw new NotImplementedException();
            if (!entry.Exists)
                entry.Value = entry.Key * arg;

            return null;
        }
    }
}
