using System;
using System.Collections.Generic;
using System.Text;
using Apache.Ignite.Core.Cache.Store;
using Apache.Ignite.Core.Common;

namespace IgniteDotNetApp
{
    class EmployeeStoreFactory : IFactory<ICacheStore>
    {
        public ICacheStore CreateInstance()
        {
            return new EmployeeStore();
        }
    }
}
