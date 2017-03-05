namespace SoftUniStore.Data
{
    using System;
    using SoftUniStore.Data.Repositories;

    public class UnitOfWork
    {
        private bool disposed;

        private SoftUniStoreDbContext context;
        private UsersRepository usersRepository;
        private GamesRepository gamesRepository;
        private LoginsRepository loginsRepository;

        public UnitOfWork()
        {
            this.context = new SoftUniStoreDbContext();
            this.disposed = false;
        }

        public UsersRepository UsersRepository
            => this.usersRepository ?? (this.usersRepository = new UsersRepository(this.context));

        public GamesRepository GamesRepository
            => this.gamesRepository ?? (this.gamesRepository = new GamesRepository(this.context));

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
