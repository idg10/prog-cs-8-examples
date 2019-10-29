using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AnonymousFunctions
{
    public class DataAccess
    {
        public static void Query()
        {
            using var dbContext = new Context();

            var expensiveProducts = dbContext.Products.Where(p => p.ListPrice > 3000);
        }

        public class Context : DbContext
        {
            public DbSet<Product> Products { get; set; }
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal ListPrice { get; set; }
        }
    }
}