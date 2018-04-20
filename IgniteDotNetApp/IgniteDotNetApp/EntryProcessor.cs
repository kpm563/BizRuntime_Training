using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache;
using System;
using System.Linq;

namespace IgniteDotNetApp
{
    class EntryProcessor
    {
        private const string CacheName = "cache_put_get";

        private const int EntryCount = 20;

        private static void PrintCacheEntries(ICache<int, int> cache)
        {
            Console.WriteLine("\n>>> Entries in cache:");

            foreach (var entry in cache)
                Console.WriteLine(entry);
        }

        public static void EntryCaller()
        {
            using (var ignite = Ignition.Start())
            {
                Console.WriteLine();
                Console.WriteLine(">>> Cache EntryProcessor example started.");

                ICache<int, int> cache = ignite.GetOrCreateCache<int, int>(CacheName);
                cache.Clear();

                // Populate cache with Invoke.
                int[] keys = Enumerable.Range(1, EntryCount).ToArray();

                foreach (var key in keys)
                    cache.Invoke(key, new CachePutEntryProcessor(), 10);

                PrintCacheEntries(cache);

                // Increment entries by 5 with InvokeAll.
                cache.InvokeAll(keys, new CacheIncrementEntryProcessor(), 5);

                PrintCacheEntries(cache);
            }

            Console.WriteLine();
        }
    }
}
