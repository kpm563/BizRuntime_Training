using System;
using System.Collections.Generic;
using System.Text;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache.Configuration;

namespace IgniteDotNetApp
{
    class StoreExample
    {
        private const string CacheName = "cache_with_store";


        public static void StoreCaller()
        {
            using (var ignite = Ignition.Start())
            {
                Console.WriteLine();
                Console.WriteLine(">>> Cache store started ::: ");

                var cache = ignite.GetOrCreateCache<int, Employee>(new CacheConfiguration
                {
                    Name = CacheName,
                    ReadThrough = true,
                    WriteThrough = true,
                    KeepBinaryInStore = false,
                    CacheStoreFactory = new EmployeeStoreFactory()
                });

                cache.Clear();

                Console.WriteLine();
                Console.WriteLine(">>> Loaded entry from store through ICache.LoadCache().");
                Console.WriteLine(">>> Current cache size: " + cache.GetSize());

                Employee emp = cache.Get(2);

                Console.WriteLine();
                Console.WriteLine(">>> Loaded entry from store through ICache.Get(): " + emp);
                Console.WriteLine(">>> Current cache size: " + cache.GetSize());


                cache.Put(3, new Employee(
                    "James Wilson",
                    12500,
                    new Address("1096 Eddy Street, San Francisco, CA", 94109),
                    new List<string> { "Human Resources", "Customer Service" }
                ));


                Console.WriteLine();
                Console.WriteLine(">>> Put entry to cache. ");
                Console.WriteLine(">>> Current cache size: " + cache.GetSize());


                cache.Clear();

                Console.WriteLine();
                Console.WriteLine(">>> Cleared values from cache again.");
                Console.WriteLine(">>> Current cache size: " + cache.GetSize());

                Console.WriteLine();
                Console.WriteLine(">>> Read values after clear:");

                for (int i = 1; i <= 3; i++)
                    Console.WriteLine(">>>     Key=" + i + ", value=" + cache.Get(i));
            }
        }
    }
}
