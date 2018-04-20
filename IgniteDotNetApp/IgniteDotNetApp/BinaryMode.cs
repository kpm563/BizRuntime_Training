using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Cache.Query;
using System;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache.Configuration;

namespace IgniteDotNetApp
{
    class BinaryMode
    {
        private const string CacheName = "binary_cache";
        private const string PersonType = "Person";
        private const string CompanyName = "company";
        private const string NameField = "Name";
        private const string CompanyIdField = "CompanyId";
        private const string IdField = "Id";
        private const string CompanyType = "Company";


        private static void ReadModify(ICache<int, IBinaryObject> cache)
        {
            const int id = 1;
            IBinaryObject person = cache[id];

            string name = person.GetField<string>(NameField);

            Console.WriteLine();
            Console.WriteLine(">>> Name of the person with id {0}: {1}", id, name);

            cache[id] = person.ToBuilder().SetField("Name", name + " Jr.").Build();

            Console.WriteLine(">>> Modified person with id {0}: {1}", id, cache[1]);
        }

        private static void SqlQuery(ICache<int, IBinaryObject> cache)
        {
            var qry = cache.Query(new SqlQuery(PersonType, "name like 'James%'"));

            Console.WriteLine();
            Console.WriteLine(">>> Persons named James:");

            foreach (var entry in qry)
                Console.WriteLine(">>>    " + entry.Value);
        }

        private static void SqlJoinQuery(ICache<int, IBinaryObject> cache)
        {
            const string orgName = "Apache";

            var qry = cache.Query(new SqlQuery(PersonType,
                "from Person, Company " +
                "where Person.CompanyId = Company.Id and Company.Name = ?", orgName)
            {
                EnableDistributedJoins = true
            });

            Console.WriteLine();
            Console.WriteLine(">>> Persons working for " + orgName + ":");

            foreach (var entry in qry)
                Console.WriteLine(">>>     " + entry.Value);
        }

        private static void SqlFieldsQuery(ICache<int, IBinaryObject> cache)
        {
            var qry = cache.Query(new SqlFieldsQuery("select name from Person order by name"));

            Console.WriteLine();
            Console.WriteLine(">>> All person names:");

            foreach (var row in qry)
                Console.WriteLine(">>>     " + row[0]);
        }

        private static void FullTextQuery(ICache<int, IBinaryObject> cache)
        {
            var qry = cache.Query(new TextQuery(PersonType, "Peters"));

            Console.WriteLine();
            Console.WriteLine(">>> Persons named Peters:");

            foreach (var entry in qry)
                Console.WriteLine(">>>     " + entry.Value);
        }


        private static void PopulateCache(ICache<int, IBinaryObject> cache)
        {
            IBinary binary = cache.Ignite.GetBinary();

            // Populate persons.
            cache[1] = binary.GetBuilder(PersonType)
                .SetField(NameField, "James Wilson")
                .SetField(CompanyIdField, -1)
                .Build();

            cache[2] = binary.GetBuilder(PersonType)
                .SetField(NameField, "Daniel Adams")
                .SetField(CompanyIdField, -1)
                .Build();

            cache[3] = binary.GetBuilder(PersonType)
                .SetField(NameField, "Cristian Moss")
                .SetField(CompanyIdField, -1)
                .Build();

            cache[4] = binary.GetBuilder(PersonType)
                .SetField(NameField, "Allison Mathis")
                .SetField(CompanyIdField, -2)
                .Build();

            cache[5] = binary.GetBuilder(PersonType)
                .SetField(NameField, "Breana Robbin")
                .SetField(CompanyIdField, -2)
                .Build();

            cache[6] = binary.GetBuilder(PersonType)
                .SetField(NameField, "Philip Horsley")
                .SetField(CompanyIdField, -2)
                .Build();

            cache[7] = binary.GetBuilder(PersonType)
                .SetField(NameField, "James Peters")
                .SetField(CompanyIdField, -2)
                .Build();

            // Populate companies.
            cache[-1] = binary.GetBuilder(CompanyType)
                .SetField(NameField, "Apache")
                .SetField(IdField, -1)
                .Build();

            cache[-2] = binary.GetBuilder(CompanyType)
                .SetField(NameField, "Microsoft")
                .SetField(IdField, -2)
                .Build();
        }


        public static void BinaryModeCaller()
        {
            using (var ignite = Ignition.Start())
            {
                Console.WriteLine();
                Console.WriteLine(">>> Binary mode example started.");

                var cache0 = ignite.GetOrCreateCache<object, object>(new CacheConfiguration
                {
                    Name = CacheName,
                    QueryEntities = new[]
                    {
                        new QueryEntity
                        {
                            KeyType = typeof(int),
                            ValueTypeName = PersonType,
                            Fields = new[]
                            {
                                new QueryField(NameField, typeof(string)),
                                new QueryField(CompanyIdField, typeof(int))
                            },
                            Indexes = new[]
                            {
                                new QueryIndex(false, QueryIndexType.FullText, NameField),
                                new QueryIndex(false, QueryIndexType.Sorted, CompanyIdField)
                            }
                        },
                        new QueryEntity
                        {
                            KeyType = typeof(int),
                            ValueTypeName = CompanyType,
                            Fields = new[]
                            {
                                new QueryField(IdField, typeof(int)),
                                new QueryField(NameField, typeof(string))
                            }
                        }
                    }
                });



                // Switch to binary mode to work with data in serialized form.
                var cache = cache0.WithKeepBinary<int, IBinaryObject>();

                // Clean up caches on all nodes before run.
                cache.Clear();

                // Populate cache with sample data entries.
                PopulateCache(cache);

                // Run read & modify example.
                ReadModify(cache);

                // Run SQL query example.
                SqlQuery(cache);

                // Run SQL query with join example.
                SqlJoinQuery(cache);

                // Run SQL fields query example.
                SqlFieldsQuery(cache);

                // Run full text query example.
                FullTextQuery(cache);

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine(">>> Example finished, press any key to exit ...");
            Console.ReadKey();
        }
    }
}
