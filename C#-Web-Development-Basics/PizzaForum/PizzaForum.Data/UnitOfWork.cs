namespace PizzaForum.Data
{
    using System;
    using PizzaForum.Data.Repositories;

    public class UnitOfWork
    {
        private bool disposed;

        private PizzaForumDbContext context;
        private CategoriesRepository categoriesRepository;
        private RepliesRepository repliesRepository;
        private TopicsRepository topicsRepository;
        private UsersRepository usersRepository;
        private LoginsRepository loginsRepository;

        public UnitOfWork()
        {
            this.context = new PizzaForumDbContext();
            this.disposed = false;
        }

        public CategoriesRepository CategoriesRepository 
            => this.categoriesRepository ?? (this.categoriesRepository = new CategoriesRepository(this.context));

        public RepliesRepository RepliesRepository
            => this.repliesRepository ?? (this.repliesRepository = new RepliesRepository(this.context));

        public TopicsRepository TopicsRepository
            => this.topicsRepository ?? (this.topicsRepository = new TopicsRepository(this.context));

        public UsersRepository UsersRepository
            => this.usersRepository ?? (this.usersRepository = new UsersRepository(this.context));

        public LoginsRepository LoginsRepository
            => this.loginsRepository ?? (this.loginsRepository = new LoginsRepository(this.context));

        public void Save()
        {
            this.context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
