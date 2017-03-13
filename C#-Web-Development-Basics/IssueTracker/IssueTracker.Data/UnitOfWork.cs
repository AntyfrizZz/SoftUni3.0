namespace IssueTracker.Data
{
    using System;
    using IssueTracker.Data.Repositories;

    public class UnitOfWork
    {
        private bool disposed;

        private IssueTrackerDbContext context;
        private UsersRepository usersRepository;
        private IssuesRepository issuesRepository;
        private LoginRepository loginRepository;

        public UnitOfWork()
        {
            this.context = new IssueTrackerDbContext();
            this.disposed = false;
        }

        public UsersRepository UsersRepository
            => this.usersRepository ?? (this.usersRepository = new UsersRepository(this.context));

        public IssuesRepository IssuesRepository
            => this.issuesRepository ?? (this.issuesRepository = new IssuesRepository(this.context));

        public LoginRepository LoginRepository
            => this.loginRepository ?? (this.loginRepository = new LoginRepository(this.context));

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
