namespace CarDealer.App.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using Data.Services;
    using Models.BindingModels.Users;
    using Security;

    [RoutePrefix("users")]
    public class UsersController : Controller
    {
        private UsersService service;

        public UsersController()
        {
            this.service = new UsersService();
        }

        [HttpGet]
        [Route("register/")]
        public ActionResult Register()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All", "Cars");
            }

            return this.View();
        }

        [HttpPost]
        [Route("register/")]
        public ActionResult Register(RegisterUserBm bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All", "Cars");
            }

            if (this.ModelState.IsValid)
            {
                this.service.RegisterUser(bind);
                return this.RedirectToAction("Login");
            }

            return this.RedirectToAction("Register");
        }

        [HttpGet]
        [Route("login/")]
        public ActionResult Login()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All", "Cars");
            }

            return this.View();
        }

        [HttpPost]
        [Route("login/")]
        public ActionResult Login(LoginUserBm bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All", "Cars");
            }

            if (this.ModelState.IsValid && this.service.UserExists(bind))
            {
                this.service.LoginUser(bind, Session.SessionID);
                this.Response.SetCookie(new HttpCookie("sessionId", Session.SessionID));
                return this.RedirectToAction("All", "Cars");
            }

            return this.RedirectToAction("Login");
        }

        [HttpPost]
        [Route("logout")]
        public ActionResult Logout()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");

            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login");
            }

            AuthenticationManager.Logout(Request.Cookies.Get("sessionId").Value);
            return this.RedirectToAction("All", "Cars");
        }
    }
}