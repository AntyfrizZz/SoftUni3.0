namespace CarDealer.Data.Services
{
    using System.Linq;
    using AutoMapper;
    using Models.BindingModels.Users;
    using Models.EntityModels;

    public class UsersService : Service
    {
        public void RegisterUser(RegisterUserBm bind)
        {
            User model = Mapper.Map<RegisterUserBm, User>(bind);
            this.Context.Users.Add(model);
            this.Context.SaveChanges();
        }

        public bool UserExists(LoginUserBm bind)
        {
            return this.Context.Users
                .Any(user => user.Username == bind.Username && user.Password == bind.Password);
        }

        public void LoginUser(LoginUserBm bind, string sessionID)
        {
            Login login = this.Context.Logins.FirstOrDefault(l => l.SessionId == sessionID);

            if (login == null)
            {
                login = new Login()
                {
                    SessionId = sessionID
                };
            }

            login.IsActive = true;

            login.User = this.Context.Users
                .FirstOrDefault(user => user.Username == bind.Username && user.Password == bind.Password);

            this.Context.Logins.Add(login);
            this.Context.SaveChanges();
        }
    }
}
