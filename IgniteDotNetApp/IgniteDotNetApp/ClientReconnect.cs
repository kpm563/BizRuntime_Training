using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Cache.Configuration;
using Apache.Ignite.Core.Common;
using Apache.Ignite.Core.Discovery.Tcp;
using Apache.Ignite.Core.Discovery.Tcp.Static;
using Apache.Ignite.Core.Events;
using System;
using System.Threading;

namespace IgniteDotNetApp
{
    class ClientReconnect
    {
        private const string CacheName = "client_reconnect";

        private static void RunServer(WaitHandle evt)
        {
            var cfg = new IgniteConfiguration(GetIgniteConfiguration())
            {
                IgniteInstanceName = "serverNode",
                CacheConfiguration = new[] {new CacheConfiguration(CacheName)},
                IncludedEventTypes = new[] {EventType.NodeJoined}
            };

            using (var ignite = Ignition.Start(cfg))
            {
                Console.WriteLine("\n>>> Server node started :::::::: ");

                if (ignite.GetCluster().GetNodes().Count==1)
                {
                    ignite.GetEvents().WaitForLocal(EventType.NodeJoined);
                }

                Console.WriteLine("\n>>> Server node stopped!!!");

                Thread.Sleep(15000);

                Console.WriteLine("\n>>>Restarting server node.........");

                using (Ignition.Start(cfg))
                {
                    evt.WaitOne();
                }
            }

        }

        private static IgniteConfiguration GetIgniteConfiguration()
        {
            return new IgniteConfiguration
            {
                DiscoverySpi = new TcpDiscoverySpi
                {
                    IpFinder = new TcpDiscoveryStaticIpFinder
                    {
                        Endpoints = new[] { "127.0.0.1:47500" }
                    }
                }
            };
        }


        public static void ClientReconnectCaller()
        {
            Console.WriteLine();
            Console.WriteLine(">>>  Client Reconnect started ........");

            var evt = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem(_ => RunServer(evt));
            Thread.Sleep(200);

            var cfg = new IgniteConfiguration(GetIgniteConfiguration())
            {
                ClientMode = true
            };

            using (var ignite = Ignition.Start(cfg))
            {
                Console.WriteLine(">>>> Client node connected to the cluster ......!");
                if (ignite.GetCluster().GetNodes().Count>2)
                {
                    throw new Exception("Extra node detected, ClientReconnect should run without external nodes." );
                }

                var cache = ignite.GetCache<int, string>(CacheName);

                for (var i = 0; i < 10; i++)
                {
                    try
                    {
                        Console.WriteLine(">>> Put value with key :: " + i);
                        cache.Put(i, "val" + i);

                        Thread.Sleep(500);
                    }
                    catch (CacheException e)
                    {
                        var disconnectedException = e.InnerException as ClientDisconnectedException;

                        if (disconnectedException != null)
                        {
                            Console.WriteLine("\n>>> Client disconnected from the cluster. Failed to put value with key: " + i);

                            disconnectedException.ClientReconnectTask.Wait();

                            Console.WriteLine("\n>>> Client reconnected to the cluster.");
                            
                            cache = ignite.GetCache<int, string>(CacheName);
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                evt.Set();

                Console.WriteLine();
                Console.WriteLine(">>> Example finished, press any key to exit ...");
            }
        }
    }
}
