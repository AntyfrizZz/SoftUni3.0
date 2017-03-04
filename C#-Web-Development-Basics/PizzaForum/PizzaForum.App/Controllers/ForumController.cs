namespace PizzaForum.App.Controllers
{
    using PizzaForum.App.BindingModels;
    using PizzaForum.App.Services;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleHttpServer.Models;

    public class ForumController : Controller
    {
        private ForumService service;

        public ForumController()
        {
            this.service = new ForumService();
        }

        [HttpGet]
        public IActionResult Register(HttpSession session, HttpResponse response)
        {
            if (this.service.IsAutenticated(session.Id))
            {
                this.Redirect(response, "/home/topics");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpResponse response, RegisterUserBindingModel model)
        {
            if (!this.service.IsRegisterModelValid(model))
            {
                this.Redirect(response, "/forum/register");
                return null;
            }

            var user = this.service.GetUserFromRegisterBind(model);
            this.service.RegisterUser(user);

            this.Redirect(response, "/forum/login");
            return null;
        }

        [HttpGet]
        public IActionResult Login(HttpSession session, HttpResponse response)
        {
            if (this.service.IsAutenticated(session.Id))
            {
                this.Redirect(response, "/home/topics");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session, LoginUserBindingModel model)
        {
            if (!this.service.IsLoginModelValid(model))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            var user = this.service.GetUserFromLoginBind(model);

            this.service.LoginUser(user, session.Id);
            ViewBag.Bag["username"] = user.Username;
            this.Redirect(response, "/home/topics");
            return null;
        }
    }
}
