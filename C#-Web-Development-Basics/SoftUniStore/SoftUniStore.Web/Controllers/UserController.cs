namespace SoftUniStore.Web.Controllers
{
    using AutoMapper;
    using Data.Services;
    using Models;
    using Models.BindingModels;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class UserController : Controller
    {
        private UserService service;

        public UserController()
        {
            this.service = new UserService();
        }

        [HttpGet]
        public IActionResult Register(HttpSession session, HttpResponse response)
        {
            if (this.service.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpResponse response, UserRegisterBindingModel model)
        {
            if (!this.service.IsRegisterModelValid(model))
            {
                return this.View();
            }

            User user = Mapper.Map<UserRegisterBindingModel, User>(model);

            this.service.RegisterUser(user);
            this.Redirect(response, "/user/login");
            return null;            
        }

        [HttpGet]
        public IActionResult Login(HttpSession session, HttpResponse response)
        {
            if (this.service.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session, UserLoginBindingModel model)
        {
            User user = this.service.GetUser(model);
            if (user == null)
            {
                this.Redirect(response, "/user/login");
                return null;
            }

            this.service.LoginUser(user, session.Id);
            this.Redirect(response, "/home/index?filter=all");
            return null;
        }

        [HttpGet]
        public void Logout(HttpResponse response, HttpSession session)
        {
            if (!this.service.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/home/index");
            }

            this.service.Logout(response, session.Id);
            this.Redirect(response, "/user/login");
        }
    }
}
