using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityCRUDCore.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=.\\SQLSERVER;Initial Catalog=PersonDb;Persist Security Info=True;User ID=sa;Password=prince");
        }
    }
}
