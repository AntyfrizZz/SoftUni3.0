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
        private ForumService forumService;

        public ForumController()
        {
            this.forumService = new ForumService();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpResponse response, RegisterUserBindingModel model)
        {
            if (!this.forumService.IsRegisterModelValid(model))
            {
                this.Redirect(response, "/forum/register");
                return null;
            }

            var user = this.forumService.GetUserFromBind(model);
            this.forumService.RegisterUser(user);

            this.Redirect(response, "/forum/login");
            return null;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session, LoginUserBindingModel model)
        {
            
        }
    }
}
