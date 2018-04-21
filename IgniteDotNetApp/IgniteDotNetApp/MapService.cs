using System;
using System.Collections.Generic;
using System.Text;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Resource;
using Apache.Ignite.Core.Services;

namespace IgniteDotNetApp
{
    class MapService<TK, TV>:IService
    {
        [InstanceResource] private readonly IIgnite _ignite;

        private ICache<TK, TV> _cache;

        public int Size
        {
            get { return _cache.GetSize(); }
        }

        public void Init(IServiceContext context)
        {
            //throw new NotImplementedException();
            _cache = _ignite.GetOrCreateCache<TK, TV>("MapService_" + context.Name);
            Console.WriteLine("Service Initialized :: " + context.Name);
        }

        public void Execute(IServiceContext context)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Service started :: " + context.Name);
        }

        public void Cancel(IServiceContext context)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Service Cancelled :: " + context.Name);
        }

        public void Put(TK key, TV value)
        {
            _cache.Put(key, value);
        }

        public TV Get(TK key)
        {
            return _cache.Get(key);
        }

        public void Clear()
        {
            _cache.Clear();
        }
    }
}
