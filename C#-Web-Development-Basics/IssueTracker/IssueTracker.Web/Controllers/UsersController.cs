using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Data.Services;
using IssueTracker.Models.BindingModels;
using IssueTracker.Models.ViewModels;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace IssueTracker.Web.Controllers
{
    public class UsersController : Controller
    {
        private UserService service;

        public UsersController()
        {
            this.service = new UserService();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpSession session, HttpResponse response, LoginUserBindingModel model)
        {
            var user = this.service.GetUser(model);

            if (user == null)
            {
                return this.View();
            }

            this.service.LoginUser(user, session.Id);
            ViewBag.Bag["username"] = user.Username;
            this.Redirect(response, "/home/index");
            return null;
        }

        [HttpGet]
        public IActionResult<HashSet<RegistrationVerificationErrorViewModel>> Register()
        {
            return this.View(new HashSet<RegistrationVerificationErrorViewModel>());
        }

        [HttpPost]
        public IActionResult<HashSet<RegistrationVerificationErrorViewModel>> Register(HttpResponse response, UserRegisterBindingModel model)
        {
            var errors = this.service.GetRegisterErrors(model);

            if (errors.Count != 0)
            {
                return this.View(errors);
            }

            this.service.RegisterUser(model);
            this.Redirect(response, "/users/login");
            return null;
        }
    }
}
