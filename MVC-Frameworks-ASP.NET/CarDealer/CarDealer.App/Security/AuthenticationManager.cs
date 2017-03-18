namespace CarDealer.App.Security
{
    using System.Linq;
    using Data;
    using Models.EntityModels;

    public class AuthenticationManager
    {
        private static CarDealerDbContext context = new CarDealerDbContext();

        public static bool IsAuthenticated(string sessionId)
        {
            if (context.Logins.Any(login => login.SessionId == sessionId && login.IsActive))
            {
                return true;
            }

            return false;
        }

        public static User GetAuthenticatedUser(string sessionId)
        {
            var firstOrDefault = context.Logins
                .FirstOrDefault(login => login.SessionId == sessionId && login.IsActive);

            if (firstOrDefault != null)
            {
                var authenticatedUser = firstOrDefault.User;

                return authenticatedUser;
            }

            return null;
        }

        public static void Logout(string sessioId)
        {
            Login login = context.Logins
                .FirstOrDefault(login1 => login1.SessionId == sessioId);

            login.IsActive = false;
            context.SaveChanges();
        }
    }
}
