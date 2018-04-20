using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Cache.Configuration;
using Apache.Ignite.Core.Transactions;

namespace IgniteDotNetApp
{
    class TransactionDeadlockDetection
    {
        private const string CacheName = "cache_tx";

        private static void UpdateKeys(ICache<int, int> cache, IEnumerable<int> keys, int threadId)
        {
            var txs = cache.Ignite.GetTransactions();
            try
            {
                using (var tx = txs.TxStart(TransactionConcurrency.Pessimistic, TransactionIsolation.ReadCommitted,
                    TimeSpan.FromSeconds(2), 0))
                {
                    foreach (var key in keys)
                    {
                        cache[key] = threadId;
                    }

                    Thread.Sleep(TimeSpan.FromSeconds(3));

                    tx.Commit();
                }
            }
            catch (TransactionDeadlockException e)
            {
                Console.WriteLine("\n>>> Transaction deadlock in thread {0} :: {1}", threadId, e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\n>>> Update failed in thread {0} :: {0}", threadId, e.Message);
            }
        }


        public static void TransationCaller()
        {
            using (var ignite = Ignition.Start())
            {
                Console.WriteLine();
                Console.WriteLine(">>> Transaction deadlock detection started :::: ");

                var cache = ignite.GetOrCreateCache<int, int>(new CacheConfiguration
                {
                    Name = CacheName,
                    AtomicityMode = CacheAtomicityMode.Transactional
                });

                cache.Clear();

                var keys = Enumerable.Range(1, 100).ToArray();
                var task1 = Task.Factory.StartNew(() => UpdateKeys(cache, keys, 1));
                var task2 = Task.Factory.StartNew(() => UpdateKeys(cache, keys.Reverse(), 2));

                Task.WaitAll(task1, task2);

            }
        }
    }
}
