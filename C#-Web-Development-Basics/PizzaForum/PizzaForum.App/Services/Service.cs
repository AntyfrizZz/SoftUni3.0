namespace PizzaForum.App.Services
{
    using System.Linq;
    using PizzaForum.Data;
    using PizzaForum.Models;

    public abstract class Service
    {
        protected UnitOfWork uow;

        public Service()
        {
            this.uow = new UnitOfWork();
        }

        internal virtual bool IsAutenticated(string sessionId)
        {
            return this.GetAutenticatedUser(sessionId) != null;
        }

        internal virtual User GetAutenticatedUser(string sessionId)
        {
            var login = this.uow.LoginsRepository
                .Get(l => l.SessionId == sessionId && l.IsActive)
                .SingleOrDefault();


            return login == null ? null : login.User;
        }
    }
}
