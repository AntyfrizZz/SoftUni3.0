using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IssueTracker.Common;
using IssueTracker.Models;
using IssueTracker.Models.BindingModels;
using IssueTracker.Models.Enums;
using IssueTracker.Models.ViewModels;
using SimpleHttpServer.Models;

namespace IssueTracker.Data.Services
{
    public class UserService : Service
    {
        public User GetUser(LoginUserBindingModel model)
        {
            return this.unitOfWork.UsersRepository
                .Get(u => u.Username == model.Username && u.Password == model.Password)
                .SingleOrDefault();
        }

        public void LoginUser(User user, string sessionId)
        {
            this.unitOfWork.LoginRepository.Insert(new Login()
            {
                SessionId = sessionId,
                User = user,
                IsActive = true
            });

            this.unitOfWork.Save();
        }

        public HashSet<RegistrationVerificationErrorViewModel> GetRegisterErrors(UserRegisterBindingModel model)
        {
            var errors = new HashSet<RegistrationVerificationErrorViewModel>();

            if (model.Username.Length < 5 || model.Username.Length > 30)
            {
                errors.Add(new RegistrationVerificationErrorViewModel(GlobalConstants.UsernameError));
            }

            if (model.Fullname.Length < 5)
            {
                errors.Add(new RegistrationVerificationErrorViewModel(GlobalConstants.FullnameError));
            }

            Regex specialSymbolrgx = new Regex(@"[!@#$%^&*,.]");
            if (model.Password.Length < 8 || 
                !model.Password.Any(char.IsUpper) || 
                !model.Password.Any(char.IsDigit) ||
                !specialSymbolrgx.IsMatch(model.Password))
            {
                errors.Add(new RegistrationVerificationErrorViewModel(GlobalConstants.PasswordError));
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add(new RegistrationVerificationErrorViewModel(GlobalConstants.ConfirmPasswordError));
            }

            return errors;
        }

        public void RegisterUser(UserRegisterBindingModel model)
        {
            var role = this.unitOfWork.UsersRepository.Any() ? Role.Regular : Role.Administrator;

            this.unitOfWork.UsersRepository.Insert(new User()
            {
                Username = model.Username,
                Fullname = model.Fullname,
                Password = model.Password,
                Role = role
            });

            this.unitOfWork.Save();
        }
    }
}
