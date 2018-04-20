using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Apache.Ignite.Core.Cache.Store;

namespace IgniteDotNetApp
{
    class EmployeeStore:CacheStoreAdapter<int, Employee>
    {
        private readonly ConcurrentDictionary<int, Employee> _db = new ConcurrentDictionary<int, Employee>(
            new List<KeyValuePair<int, Employee>>
            {
                new KeyValuePair<int, Employee>(1, new Employee(
                    "Allison Mathis",
                    25300,
                    new Address("2702 Freedom Lane, San Francisco, CA", 94109),
                    new List<string> {"Development"}
                )),

                new KeyValuePair<int, Employee>(2, new Employee(
                    "Breana Robbin",
                    6500,
                    new Address("3960 Sundown Lane, Austin, TX", 78130),
                    new List<string> {"Sales"}
                ))
            });


        public override void LoadCache(Action<int, Employee> act, params object[] args)
        {
            // Iterate over whole underlying store and call act on each entry to load it into the cache.
            foreach (var entry in _db)
                act(entry.Key, entry.Value);
        }


        public override IEnumerable<KeyValuePair<int, Employee>> LoadAll(IEnumerable<int> keys)
        {
            var result = new Dictionary<int, Employee>();

            foreach (var key in keys)
                result[key] = Load(key);

            return result;
        }

        public override Employee Load(int key)
        {
            Employee val;

            _db.TryGetValue(key, out val);

            return val;
        }

        public override void Write(int key, Employee val)
        {
            _db[key] = val;
        }

        public override void Delete(int key)
        {
            Employee val;

            _db.TryRemove(key, out val);
        }
    }
}
