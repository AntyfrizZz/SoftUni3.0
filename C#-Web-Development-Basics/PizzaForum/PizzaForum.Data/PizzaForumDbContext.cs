namespace PizzaForum.Data
{
    using System.Data.Entity;
    using PizzaForum.Models;

    public class PizzaForumDbContext : DbContext
    {
        public PizzaForumDbContext()
            : base("PizzaForumDbContext")
        {            
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Reply> Replies { get; set; }

        public virtual DbSet<Topic> Topics { get; set; }

        public virtual DbSet<Login> Logins { get; set; }
    }
}