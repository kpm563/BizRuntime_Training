using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache.Event;
using Apache.Ignite.Core.Cache.Query.Continuous;

namespace IgniteDotNetApp
{
    class ContinuousQuery
    {
        private const string CacheName = "continuous_query";

        private class Listener<T> : ICacheEntryEventListener<int, T>
        {
            public void OnEvent(IEnumerable<ICacheEntryEvent<int, T>> events)
            {
                foreach (var e in events)
                    Console.WriteLine("Queried entry [key=" + e.Key + ", val=" + e.Value + ']');
            }
        }

        public static void ContinuousQueryCaller()
        {
            using (var ignite = Ignition.Start())
            {
                Console.WriteLine();
                Console.WriteLine(">>> Cache continuous query example started.");

                var cache = ignite.GetOrCreateCache<int, string>(CacheName);

                cache.Clear();
                const int keyCnt = 20;
                for (int i = 0; i < keyCnt; i++)
                    cache.Put(i, i.ToString());

                var qry = new ContinuousQuery<int, string>(new Listener<string>(), new ContinuousQueryFilter(15));

                using (cache.QueryContinuous(qry))
                {
                    for (var i = keyCnt; i < keyCnt + 5; i++)
                        cache.Put(i, i.ToString());

                    Thread.Sleep(2000);
                }
            }

            Console.WriteLine();
            Console.WriteLine(">>> Example finished, press any key to exit ...");
        }
    }
}
