using System;
using System.Collections.Generic;
using System.Text;
using Apache.Ignite.Core.Cache.Event;

namespace IgniteDotNetApp
{
    class ContinuousQueryFilter : ICacheEntryEventFilter<int, string>
    {
        private readonly int _thresold;

        public ContinuousQueryFilter(int thresold)
        {
            _thresold = thresold;
        }

        public bool Evaluate(ICacheEntryEvent<int, string> evt)
        {
            return evt.Key >= _thresold;
        }
    }
}
