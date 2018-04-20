using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IgniteDotNetApp
{
    public class Employee
    {
        public string Name { get; set; }
        public long Salary { get; set; }
        public Address Address { get; set; }
        public int OrganisationId { get; set; }
        public ICollection<string> Departments { get; set; }

        public Employee(string name, long salary, Address address, ICollection<string> departments,
            int organisationId = 0)
        {
            Name = name;
            Salary = salary;
            Address = address;
            OrganisationId = organisationId;
            Departments = departments;
        }

        public override string ToString()
        {
            return string.Format("{0} [name={1}, salary={2}, address={3}, departments={4}]", typeof(Employee).Name,
                Name, Salary, Address, CollectionToString(Departments));
        }

        private static string CollectionToString<T>(ICollection<T> col)
        {
            if (col == null)
                return "null";

            var elements = col.Any()
                ? col.Select(x => x.ToString()).Aggregate((x, y) => x + ", " + y)
                : string.Empty;

            return string.Format("[{0}]", elements);
        }
    }
}
