using System;
using System.Collections.Generic;
using System.Text;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Cache.Affinity;
using Apache.Ignite.Core.Cache.Configuration;
using Apache.Ignite.Core.Cache.Query;

namespace IgniteDotNetApp
{
    class SqlExample
    {
        private const string OrganizationCacheName = "cache_organization";
        private const string EmployeeCacheName = "cache_employee";
        private const string EmployeeCacheNameColocated = "cache_employee_colocated";

        private static void SqlQueryExample(ICache<int, Employee> cache)
        {
            const int zip = 94109;

            var qry = cache.Query(new SqlQuery(typeof(Employee), "zip = ?", zip));

            Console.WriteLine();
            Console.WriteLine(">>> Employees with zipcode {0} (SQL):", zip);

            foreach (var entry in qry)
                Console.WriteLine(">>>    " + entry.Value);
        }


        private static void SqlJoinQueryExample(ICache<AffinityKey, Employee> cache)
        {
            const string orgName = "Apache";

            var qry = cache.Query(new SqlQuery("Employee",
                "from Employee, \"dotnet_cache_query_organization\".Organization " +
                "where Employee.organizationId = Organization._key and Organization.name = ?", orgName));

            Console.WriteLine();
            Console.WriteLine(">>> Employees working for " + orgName + ":");

            foreach (var entry in qry)
                Console.WriteLine(">>>     " + entry.Value);
        }


        private static void SqlDistributedJoinQueryExample(ICache<int, Employee> cache)
        {
            const string orgName = "Apache";

            var qry = cache.Query(new SqlQuery("Employee",
                "from Employee, \"dotnet_cache_query_organization\".Organization " +
                "where Employee.organizationId = Organization._key and Organization.name = ?", orgName)
            {
                EnableDistributedJoins = true
            });

            Console.WriteLine();
            Console.WriteLine(">>> Employees working for " + orgName + ":");

            foreach (var entry in qry)
                Console.WriteLine(">>>     " + entry.Value);
        }


        private static void SqlFieldsQueryExample(ICache<int, Employee> cache)
        {
            var qry = cache.Query(new SqlFieldsQuery("select name, salary from Employee"));

            Console.WriteLine();
            Console.WriteLine(">>> Employee names and their salaries:");

            foreach (var row in qry)
                Console.WriteLine(">>>     [Name=" + row[0] + ", salary=" + row[1] + ']');
        }


        private static void PopulateCache(ICache<int, Organisation> cache)
        {
            cache.Put(1, new Organisation(
                "Apache",
                new Address("1065 East Hillsdale Blvd, Foster City, CA", 94404),
                OrganisationType.Private,
                DateTime.Now));

            cache.Put(2, new Organisation("Microsoft",
                new Address("1096 Eddy Street, San Francisco, CA", 94109),
                OrganisationType.Private,
                DateTime.Now));
        }


        private static void PopulateCache(ICache<AffinityKey, Employee> cache)
        {
            cache.Put(new AffinityKey(1, 1), new Employee(
                "James Wilson",
                12500,
                new Address("1096 Eddy Street, San Francisco, CA", 94109),
                new[] { "Human Resources", "Customer Service" },
                1));

            cache.Put(new AffinityKey(2, 1), new Employee(
                "Daniel Adams",
                11000,
                new Address("184 Fidler Drive, San Antonio, TX", 78130),
                new[] { "Development", "QA" },
                1));

            cache.Put(new AffinityKey(3, 1), new Employee(
                "Cristian Moss",
                12500,
                new Address("667 Jerry Dove Drive, Florence, SC", 29501),
                new[] { "Logistics" },
                1));

            cache.Put(new AffinityKey(4, 2), new Employee(
                "Allison Mathis",
                25300,
                new Address("2702 Freedom Lane, San Francisco, CA", 94109),
                new[] { "Development" },
                2));

            cache.Put(new AffinityKey(5, 2), new Employee(
                "Breana Robbin",
                6500,
                new Address("3960 Sundown Lane, Austin, TX", 78130),
                new[] { "Sales" },
                2));

            cache.Put(new AffinityKey(6, 2), new Employee(
                "Philip Horsley",
                19800,
                new Address("2803 Elsie Drive, Sioux Falls, SD", 57104),
                new[] { "Sales" },
                2));

            cache.Put(new AffinityKey(7, 2), new Employee(
                "Brian Peters",
                10600,
                new Address("1407 Pearlman Avenue, Boston, MA", 12110),
                new[] { "Development", "QA" },
                2));
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



        public static void SqlCaller()
        {
            using (var ignite = Ignition.Start())
            {
                Console.WriteLine();
                Console.WriteLine(">>> Cache query example started.");

                var employeeCache = ignite.GetOrCreateCache<int, Employee>(
                    new CacheConfiguration(EmployeeCacheName, typeof(Employee)));

                var employeeCacheColocated = ignite.GetOrCreateCache<AffinityKey, Employee>(
                    new CacheConfiguration(EmployeeCacheNameColocated, typeof(Employee)));

                var organizationCache = ignite.GetOrCreateCache<int, Organisation>(
                    new CacheConfiguration(OrganizationCacheName, new QueryEntity(typeof(int), typeof(Organisation))));

                // Populate cache with sample data entries.
                PopulateCache(employeeCache);
                PopulateCache(employeeCacheColocated);
                PopulateCache(organizationCache);

                // Run SQL query example.
                //SqlQueryExample(employeeCache);

                // Run SQL query with join example.
                SqlJoinQueryExample(employeeCacheColocated);

                // Run SQL query with distributed join example.
                SqlDistributedJoinQueryExample(employeeCache);

                // Run SQL fields query example.
                SqlFieldsQueryExample(employeeCache);

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine(">>> Example finished, press any key to exit ...");
        }






    }
}
