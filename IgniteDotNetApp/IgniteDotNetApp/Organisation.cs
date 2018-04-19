using Apache.Ignite.Core.Cache.Configuration;
using System;

namespace IgniteDotNetApp
{
    public class Organisation
    {
        [QuerySqlField(IsIndexed = true)]
        public string Name { get; set; }
        public Address Address { get; set; }
        public OrganisationType Type { get; set; }
        public DateTime LastUpdated { get; set; }


        public Organisation(string name, Address address, OrganisationType type, DateTime lastUpdated)
        {
            Name = name;
            Address = address;
            Type = type;
            LastUpdated = lastUpdated;
        }

        public override string ToString()
        {
            return string.Format("{0} [name={1}, {2}, type={3}, lastUpdated={4}]", typeof(Organisation).Name,
                Name, Address, Type, LastUpdated);
        }
    }
}
