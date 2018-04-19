using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Transactions;
using System;
using System.Threading;

namespace IgniteDotNetApp
{
    class OptimisticTransaction
    {
        public const string CacheName = "optimistic";

        public static void IncrementCacheValue(ICache<int, int> cache, int threadId)
        {
            try
            {
                var transactions = cache.Ignite.GetTransactions();

                using (var tx = transactions.TxStart(TransactionConcurrency.Optimistic,
                    TransactionIsolation.Serializable))
                {
                    cache[1]++;
                    Thread.Sleep(TimeSpan.FromSeconds(2.5));
                    tx.Commit();
                }

                Console.WriteLine("\n>>> Thread {0} successfully incremented cached value.", threadId);
            }
            catch (TransactionOptimisticException ex)
            {
                Console.WriteLine("\n>>> Thread {0} failed to increment cached value. " +
                                  "Caught an expected optimistic exception: {1}", threadId, ex.Message);
            }
        }
    }
}
