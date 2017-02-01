namespace ProductDelivery.Data.Migrations
{
    using ProductsDelivery.Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsDbCondext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ProductsDbCondext context)
        {
            context.Statuses.AddOrUpdate(
                x => x.Id,
                new Status { Id = 1, Name = "Pending" },
                new Status { Id = 2, Name = "Delivered" },
                new Status { Id = 3, Name = "Declined" },
                new Status { Id = 4, Name = "In Call to Confirm" }
                );
            context.SaveChanges();
            context.Orders.AddOrUpdate(
                x => x.Id,
                new Order
                {
                    Id = 1,
                    Name = "Harry Potter 5 Game",
                    ProductType = "PC",
                    PaymentDate = new DateTime(2017, 1, 15),
                    DeliveryDate = new DateTime(2017, 2, 18),
                    Status = context.Statuses.Find(1)
                },
                new Order
                {
                    Id = 2,
                    Name = "Pandemic",
                    ProductType = "Board Game",
                    PaymentDate = new DateTime(2017, 2, 15),
                    DeliveryDate = new DateTime(2017, 3, 18),
                    Status = context.Statuses.Find(2)
                },
                new Order
                {
                    Id = 3,
                    Name = "Logitech G502",
                    ProductType = "Accessory",
                    PaymentDate = new DateTime(2017, 3, 15),
                    DeliveryDate = new DateTime(2017, 4, 18),
                    Status = context.Statuses.Find(4)
                },
                new Order
                {
                    Id = 4,
                    Name = "Warcraft: The Beginning",
                    ProductType = "DVD",
                    PaymentDate = new DateTime(2017, 2, 15),
                    DeliveryDate = new DateTime(2017, 3, 18),
                    Status = context.Statuses.Find(3)
                },
                new Order
                {
                    Id = 5,
                    Name = "Grimm's Fairy Tales",
                    ProductType = "Book",
                    PaymentDate = new DateTime(2017, 7, 15),
                    DeliveryDate = new DateTime(2017, 8, 18),
                    Status = context.Statuses.Find(2)
                }
                );
        }
    }
}
