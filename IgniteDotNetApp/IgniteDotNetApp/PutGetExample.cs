using Apache.Ignite.Core;
using System;
using System.Collections.Generic;
using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Cache;

namespace IgniteDotNetApp
{
    public class PutGetExample
    {
        public const string CacheName = "myCache";

        public static void PutGet(IIgnite ignite)
        {
            var cache = ignite.GetCache<int, Organisation>(CacheName);

            Organisation org =new Organisation("Biz RunTime IT Services Pvt. Ltd.", new Address("Sarjapur road, Bangalore", 560035), OrganisationType.Private, DateTime.Now);

            cache.Put(1, org);
            Organisation orgFromCache = cache.Get(1);

            Console.WriteLine();
            Console.WriteLine(">> Reading data from cache :: " + orgFromCache);
        }


        public static void PutGetBinary(IIgnite ignite)
        {
            var cache = ignite.GetCache<int, Organisation>(CacheName);
            Organisation org = new Organisation("Microsoft",
                new Address("1096 Eddy Street, San Francisco, CA", 94109),
                OrganisationType.Private,
                DateTime.Now);

            cache.Put(1, org);

            var binaryCache = cache.WithKeepBinary<int, IBinaryObject>();
            var binaryOrg = binaryCache.Get(1);

            string name = binaryOrg.GetField<string>("name");

            Console.WriteLine();
            Console.WriteLine(">>>> Reading Organisation name from binry object ::: " + name);
        }


        public static void PutGetAll(IIgnite ignite)
        {
            var cache = ignite.GetCache<int, Organisation>(CacheName);
            Organisation org1 = new Organisation(
                "Microsoft",
                new Address("1096 Eddy Street, San Francisco, CA", 94109),
                OrganisationType.Private,
                DateTime.Now
            );

            Organisation org2 = new Organisation(
                "Red Cross",
                new Address("184 Fidler Drive, San Antonio, TX", 78205),
                OrganisationType.NonProfit,
                DateTime.Now
            );

            var map = new Dictionary<int, Organisation> { { 1, org1 }, { 2, org2 } };
            
            cache.PutAll(map);
            
            ICollection<ICacheEntry<int, Organisation>> mapFromCache = cache.GetAll(new List<int> { 1, 2 });

            Console.WriteLine();
            Console.WriteLine(">>> Retrieved organization instances from cache:");

            foreach (ICacheEntry<int, Organisation> org in mapFromCache)
                Console.WriteLine(">>>     " + org.Value);
        }


        public static void PutAllGetAllBinary(IIgnite ignite)
        {
            var cache = ignite.GetCache<int, Organisation>(CacheName);
            
            Organisation org1 = new Organisation(
                "Microsoft",
                new Address("1096 Eddy Street, San Francisco, CA", 94109),
                OrganisationType.Private,
                DateTime.Now
            );

            Organisation org2 = new Organisation(
                "Red Cross",
                new Address("184 Fidler Drive, San Antonio, TX", 78205),
                OrganisationType.NonProfit,
                DateTime.Now
            );

            var map = new Dictionary<int, Organisation> { { 1, org1 }, { 2, org2 } };
            
            cache.PutAll(map);
            
            var binaryCache = cache.WithKeepBinary<int, IBinaryObject>();
            
            ICollection<ICacheEntry<int, IBinaryObject>> binaryMap = binaryCache.GetAll(new List<int> { 1, 2 });

            Console.WriteLine();
            Console.WriteLine(">>> Retrieved organization names from binary objects:");

            foreach (var pair in binaryMap)
                Console.WriteLine(">>>     " + pair.Value.GetField<string>("name"));
        }
    }
}
