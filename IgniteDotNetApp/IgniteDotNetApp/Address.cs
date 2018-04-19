using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Cache.Configuration;

namespace IgniteDotNetApp
{
    public class Address : IBinarizable
    {
        [QueryTextField]
        public string Street { get; set; }

        [QuerySqlField(IsIndexed = true)]
        public int Zip { get; set; }

        public Address(string street, int zip)
        {
            Street = street;
            Zip = zip;
        }



        public void WriteBinary(IBinaryWriter writer)
        {
            //throw new NotImplementedException();
            writer.WriteString("street", Street);
            writer.WriteInt("zip", Zip);
        }

        public void ReadBinary(IBinaryReader reader)
        {
            //throw new NotImplementedException();
            Street = reader.ReadString("street");
            Zip = reader.ReadInt("zip");
        }

        public override string ToString()
        {
            return string.Format("{0} [street = {1}, zip={2}]", typeof(Address).Name, Street, Zip);
        }
    }
}
