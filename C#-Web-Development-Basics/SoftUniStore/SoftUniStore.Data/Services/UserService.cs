using System;
using System.Collections.Generic;
using System.Linq;
using SoftUniStore.Common;
using SoftUniStore.Models;
using SoftUniStore.Models.BindingModels;

namespace SoftUniStore.Data.Services
{
    public class UserService : Service
    {
        public bool IsRegisterModelValid(UserRegisterBindingModel model)
        {
            if (!model.Email.Contains('@') || !model.Email.Contains('.'))
            {
                return false;
            }

            var emails = this.unitOfWork.UsersRepository.Get()
                .Select(u => u.Email)
                .ToList();

            if (emails.Contains(model.Email))
            {
                return false;
            }

            if (model.Password.Length < GlobalConstants.PasswordMinLength ||
                !model.Password.Any(char.IsUpper) ||
                !model.Password.Any(char.IsLower) ||
                !model.Password.Any(char.IsDigit))
            {
                return false;
            }

            if (model.Password != model.ConfirmPassword)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(model.Fullname))
            {
                return false;
            }

            return true;
        }

        public void RegisterUser(User user)
        {
            user.IsAdmin = !this.unitOfWork.UsersRepository.Any();

            this.unitOfWork.UsersRepository.Insert(user);
            this.unitOfWork.Save();
        }

        public User GetUser(UserLoginBindingModel model)
        {
            return this.unitOfWork.UsersRepository
                .Get(u => u.Email == model.Email && u.Password == model.Password)
                .SingleOrDefault();
        }

        public void LoginUser(User user, string sessionId)
        {
            this.unitOfWork.LoginsRepository.Insert(new Login()
            {
                SessionId = sessionId,
                User = user,
                IsActive = true
            });

            this.unitOfWork.Save();
        }
    }
}
