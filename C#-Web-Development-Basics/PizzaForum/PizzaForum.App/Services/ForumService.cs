namespace PizzaForum.App.Services
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using PizzaForum.App.BindingModels;
    using PizzaForum.Common;
    using PizzaForum.Models;

    public class ForumService : Service
    {
        internal bool IsRegisterModelValid(RegisterUserBindingModel model)
        {
            if (model.Username.Length < 3)
            {
                return false;
            }
            
            if (this.uow.UsersRepository.Get(u => u.Username == model.Username || u.Email == model.Email).SingleOrDefault() != null)
            {
                return false;
            }

            Regex regex = new Regex(GlobalConstants.UsernamePattern);

            if (!regex.IsMatch(model.Username))
            {
                return false;
            }

            if (!model.Email.Contains("@"))
            {
                return false;
            }

            regex = new Regex(GlobalConstants.PasswordPattern);

            if (!regex.IsMatch(model.Password))
            {
                return false;
            }

            if (!model.Password.Equals(model.ConfirmPassword))
            {
                return false;
            }       

            return true;
        }

        internal void RegisterUser(User user)
        {
            if (!this.uow.UsersRepository.Any())
            {
                user.IsAdmin = true;
            }

            this.uow.UsersRepository.Insert(user);
            this.uow.Save();
        }

        internal User GetUserFromRegisterBind(RegisterUserBindingModel model)
        {
            var user = new User();
            user.Username = model.Username;
            user.Password = model.Password;
            user.Email = model.Email;

            return user;
        }

        internal void LoginUser(User user, string id)
        {
            this.uow.LoginsRepository.Insert(new Login()
            {
                SessionId = id,
                User = user,
                IsActive = true
            });

            this.uow.Save();
        }

        internal bool IsLoginModelValid(LoginUserBindingModel model)
        {
            var user = this.GetUserFromLoginBind(model);

            return user != null;
        }

        internal User GetUserFromLoginBind(LoginUserBindingModel model)
        {
            return this.uow.UsersRepository
                .Get(u => (u.Username == model.Credential || u.Email == model.Credential) && u.Password == model.Password)
                .SingleOrDefault();
        }
    }
}
