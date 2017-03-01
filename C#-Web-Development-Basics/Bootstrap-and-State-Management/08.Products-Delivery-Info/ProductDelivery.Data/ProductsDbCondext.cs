using ProductDelivery.Data.Migrations;
using ProductsDelivery.Models;
using System.Data.Entity;

namespace ProductDelivery.Data
{
    public class ProductsDbCondext : DbContext
    {
        public ProductsDbCondext()
            :base ("MSSQLLocalDB")
        {
            
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Status> Statuses { get; set; }
    }
}
