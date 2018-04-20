using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Cache.Configuration;
using Apache.Ignite.Core.Cache.Query;

namespace IgniteDotNetApp
{
    class QueryExample
    {
        private const string EmpCacheName = "query_cache";


        private static void ScanQueryExample(ICache<int, Employee> cache)
        {
            const int zip = 94109;

            var query = cache.Query(new ScanQuery<int, Employee>(new ScanQueryFilter(zip)));

            Console.WriteLine();
            Console.WriteLine(">>> Employees with zipcode {0} (scan):", zip);

            foreach (var entry in query)
                Console.WriteLine(">>>    " + entry.Value);
        }


        private static void FullTextQuery(ICache<int, Employee> cache)
        {
            var query = cache.Query(new TextQuery("Employee", "TX"));

            Console.WriteLine();
            Console.WriteLine(">>> Employees living in texas :: ");

            foreach (var entry in query)
            {
                Console.WriteLine(">>> " + entry.Value);
            }
        }


        private static void PopulateCache(ICache<int, Employee> cache)
        {
            cache.Put(1, new Employee(
                "James Wilson",
                12500,
                new Address("1096 Eddy Street, San Francisco, CA", 94109),
                new[] { "Human Resources", "Customer Service" },
                1));

            cache.Put(2, new Employee(
                "Daniel Adams",
                11000,
                new Address("184 Fidler Drive, San Antonio, TX", 78130),
                new[] { "Development", "QA" },
                1));

            cache.Put(3, new Employee(
                "Cristian Moss",
                12500,
                new Address("667 Jerry Dove Drive, Florence, SC", 29501),
                new[] { "Logistics" },
                1));

            cache.Put(4, new Employee(
                "Allison Mathis",
                25300,
                new Address("2702 Freedom Lane, San Francisco, CA", 94109),
                new[] { "Development" },
                2));

            cache.Put(5, new Employee(
                "Breana Robbin",
                6500,
                new Address("3960 Sundown Lane, Austin, TX", 78130),
                new[] { "Sales" },
                2));

            cache.Put(6, new Employee(
                "Philip Horsley",
                19800,
                new Address("2803 Elsie Drive, Sioux Falls, SD", 57104),
                new[] { "Sales" },
                2));

            cache.Put(7, new Employee(
                "Brian Peters",
                10600,
                new Address("1407 Pearlman Avenue, Boston, MA", 12110),
                new[] { "Development", "QA" },
                2));
        }

        public static void Caller()
        {
            using (var ignite = Ignition.Start())
            {
                Console.WriteLine();
                Console.WriteLine(">>> Cache query example started.");

                var employeeCache = ignite.GetOrCreateCache<int, Employee>(
                    new CacheConfiguration(EmpCacheName, typeof(Employee)));

                // Populate cache with sample data entries.
                PopulateCache(employeeCache);

                // Run scan query example.
                ScanQueryExample(employeeCache);

                // Run full text query example.
                FullTextQuery(employeeCache);

                Console.WriteLine();
            }

            Console.WriteLine();
        }

    }
}
