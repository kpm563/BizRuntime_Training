using System;
using System.Threading.Tasks;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache.Configuration;

namespace IgniteDotNetApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            using (var ignite = Ignition.Start())
            {
                Console.WriteLine();
                //Console.WriteLine(">> Cache put get started :: ");

                //ignite.GetOrCreateCache<object, object>(PutGetExample.CacheName).Clear();
                //PutGetExample.PutGet(ignite);
                //PutGetExample.PutGetBinary(ignite);
                //PutGetExample.PutGetAll(ignite);
                //PutGetExample.PutAllGetAllBinary(ignite);


                Console.WriteLine();
                Console.WriteLine(">>> Optimistic transaction example started.");
                var cacheCfg = new CacheConfiguration(OptimisticTransaction.CacheName) { AtomicityMode = CacheAtomicityMode.Transactional };

                var cache = ignite.GetOrCreateCache<int, int>(cacheCfg);

                cache[1] = 0;

                var task1 = Task.Factory.StartNew(() => OptimisticTransaction.IncrementCacheValue(cache, 1));
                var task2 = Task.Factory.StartNew(() => OptimisticTransaction.IncrementCacheValue(cache, 2));

                Task.WaitAll(task1, task2);

                Console.WriteLine();
                Console.WriteLine(">>> Resulting value in cache: " + cache[1]);

                Console.WriteLine();
            }

            //NearCache.NearCacheExample();



            Console.WriteLine("\n>>> Press any key to exit ...");
            Console.ReadKey();
        }
    }
}
