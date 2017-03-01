namespace SimpleMVC.App.MVC.Security
{
    using System.Linq;
    using Interfaces.Security;
    using SimpleHttpServer.Models;

    public class SignInManager
    {
        private IDbIdentityContext dbContext;

        public SignInManager(IDbIdentityContext context)
        {
            this.dbContext = context;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            if (session == null)
            {
                return false;
            }

            var sess = this.dbContext.Logins.FirstOrDefault(s => s.SessionId == session.Id && s.IsActive == true);

            return sess != null;
        }

        internal void Logout(HttpSession session)
        {
            var login = this.dbContext.Logins.FirstOrDefault(s => s.SessionId == session.Id && s.IsActive == true);
            login.IsActive = false;
            this.dbContext.SaveChanges();
        }
    }
}