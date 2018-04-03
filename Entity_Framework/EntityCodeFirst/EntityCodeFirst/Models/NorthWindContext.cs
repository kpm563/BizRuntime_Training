using System.Data.Entity;

namespace EntityCodeFirst.Models
{
    public class NorthWindContext : DbContext
    {
        public NorthWindContext()
        :base("name=NorthWindConnection")
        {

        }

        public DbSet<Category> CategoriesTable { get; set; }
        public DbSet<Product> ProductsTable { get; set; }

    }
}