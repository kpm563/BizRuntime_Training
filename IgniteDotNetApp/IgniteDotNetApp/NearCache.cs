using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Cache.Configuration;
using Apache.Ignite.Core.Cache.Eviction;
using System;

namespace IgniteDotNetApp
{
    class NearCache
    {
        private const string CacheName = "near_cache";

        public static void NearCacheExample()
        {
            Ignition.ClientMode = true;
            using (var ignite = Ignition.Start())
            {
                Console.WriteLine(">>> Client node connected to the cluster");

                var nearCacheCfg = new NearCacheConfiguration
                {
                    EvictionPolicy = new LruEvictionPolicy
                    {
                        MaxSize = 10
                    }
                };

                Console.WriteLine(">>> Populating the cache...");

                ICache<int, int> cache = ignite.GetOrCreateCache<int, int>(
                    new CacheConfiguration(CacheName), nearCacheCfg);
                for (int i = 0; i < 1000; i++)
                    cache.Put(i, i * 10);

                Console.WriteLine(">>> Cache size: [Total={0}, Near={1}]",
                    cache.GetSize(), cache.GetSize(CachePeekMode.Near));

                Console.WriteLine("\n>>> Reading from near cache...");

                foreach (var entry in cache.GetLocalEntries(CachePeekMode.Near))
                    Console.WriteLine(entry);
            }
        }
    }
}
