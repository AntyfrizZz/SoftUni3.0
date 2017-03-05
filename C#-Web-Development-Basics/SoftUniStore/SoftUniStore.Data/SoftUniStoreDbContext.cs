namespace SoftUniStore.Data
{
    using System.Data.Entity;
    using SoftUniStore.Models;

    public class SoftUniStoreDbContext : DbContext
    {
        public SoftUniStoreDbContext()
            : base("SoftUniStoreDbContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Login> Logins { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}