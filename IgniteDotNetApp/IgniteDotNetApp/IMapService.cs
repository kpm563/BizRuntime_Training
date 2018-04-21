using System;
using System.Collections.Generic;
using System.Text;

namespace IgniteDotNetApp
{
    public interface IMapService<TK, TV>
    {
        void Put(TK key, TV value);
        TV Get(TK key);
        void Clear();
        int Size { get; }
    }
}
