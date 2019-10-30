using Microsoft.EntityFrameworkCore;

namespace StandardOperators
{
    public class ExampleDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }

    }

    public class Product
    {
        public string Name { get; set; }

        public decimal ListPrice { get; set; }

        public double Size { get; set; }
    }
}
