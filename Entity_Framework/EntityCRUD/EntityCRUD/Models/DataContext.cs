using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EntityCRUD.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("conn")
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}