using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;
using SoftUniStore.Models;

namespace SoftUniStore.Data.Services
{
    public abstract class Service
    {
        protected UnitOfWork unitOfWork;

        public Service()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public bool IsAuthenticated(string sessionId)
        {
            return this.unitOfWork.LoginsRepository.Any(login => login.SessionId == sessionId && login.IsActive);
        }

        public bool IsAdmin(string sessionId)
        {
            return this.GetUserFromSession(sessionId).IsAdmin;
        }

        public void Logout(HttpResponse response, string sessionId)
        {
            Login currentLogin = this.unitOfWork.LoginsRepository.Get(l => l.SessionId == sessionId && l.IsActive).SingleOrDefault();
            currentLogin.IsActive = false;
            this.unitOfWork.Save();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }

        protected User GetUserFromSession(string sessionId)
        {
            var login = this.unitOfWork.LoginsRepository.Get(l => l.SessionId == sessionId && l.IsActive)
                .SingleOrDefault();

            return this.unitOfWork.UsersRepository.GetByID(login.UserId);
        }
    }
}
