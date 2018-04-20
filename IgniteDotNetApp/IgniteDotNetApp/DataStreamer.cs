using Apache.Ignite.Core;
using System;
using System.Diagnostics;

namespace IgniteDotNetApp
{
    class DataStreamer
    {
        private const long EntryCount = 1000000000;
        private const string CacheName = "cache_data_streamer";

        public static void DataStreamerMethod()
        {
            using (var ignite = Ignition.Start())
            {
                Console.WriteLine();
                Console.WriteLine(">>> Cache data streamer example started.");

                // Clean up caches on all nodes before run.
                ignite.GetOrCreateCache<int, Account>(CacheName).Clear();

                Stopwatch timer = new Stopwatch();

                timer.Start();

                using (var ldr = ignite.GetDataStreamer<int, Account>(CacheName))
                {
                    ldr.PerNodeBufferSize = 1024;

                    for (int i = 0; i < EntryCount; i++)
                    {
                        ldr.AddData(i, new Account(i, i));

                        // Print out progress while loading cache.

                        if (i > 0 && i % 10000 == 0)
                            Console.WriteLine("Loaded " + i + " accounts.");
                    }
                }

                timer.Stop();

                long dur = timer.ElapsedMilliseconds;

                Console.WriteLine(">>> Loaded " + EntryCount + " accounts in " + dur + "ms.");
            }

            Console.WriteLine();
            Console.WriteLine(">>> Example finished, press any key to exit ...");
        }
    }
}
