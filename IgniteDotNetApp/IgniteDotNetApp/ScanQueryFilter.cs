using System;
using System.Collections.Generic;
using System.Text;
using Apache.Ignite.Core.Cache;

namespace IgniteDotNetApp
{
    class ScanQueryFilter:ICacheEntryFilter<int, Employee>
    {
        private readonly int _zipCode;

        public ScanQueryFilter(int zipCode)
        {
            _zipCode = zipCode;
        }

        public bool Invoke(ICacheEntry<int, Employee> entry)
        {
            return entry.Value.Address.Zip == _zipCode;
        }
    }
}
