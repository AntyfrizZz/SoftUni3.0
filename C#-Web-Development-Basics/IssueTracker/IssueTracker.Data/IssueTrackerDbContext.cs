namespace IssueTracker.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using IssueTracker.Models;

    public class IssueTrackerDbContext : DbContext
    {

        public IssueTrackerDbContext()
            : base("IssueTrackerDbContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Issue> Issues { get; set; }

        public virtual DbSet<Login> Logins { get; set; }
    }

}