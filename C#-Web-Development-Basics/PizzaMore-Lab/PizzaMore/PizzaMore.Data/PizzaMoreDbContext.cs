namespace PizzaMore.Data
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PizzaMoreDbContext : DbContext
    {
        // Your context has been configured to use a 'PizzaMoreDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PizzaMore.Data.PizzaMoreDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PizzaMoreDbContext' 
        // connection string in the application configuration file.
        public PizzaMoreDbContext()
            : base("name=PizzaMoreDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Pizza> Pizzas { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}