namespace CarDealer.Data.Services
{
    using System;
    using Models.EntityModels;

    public class Service
    {
        private CarDealerDbContext context;

        protected Service()
        {
            this.context = new CarDealerDbContext();
        }

        protected CarDealerDbContext Context => this.context;

        protected void AddLog(object userId, OperationLog operation, string modifiedTable)
        {
            User loggedUser = this.Context.Users.Find(userId);
            Log log = new Log()
            {
                User = loggedUser,
                ModifiedAt = DateTime.Now,
                ModifiedTableName = modifiedTable,
                Operation = operation
            };

            this.Context.Logs.Add(log);
            this.Context.SaveChanges();
        }
    }
}
