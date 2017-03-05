namespace SoftUniStore.Web.Controllers
{
    using System.Collections.Generic;
    using Data.Services;
    using Models.ViewModels;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces.Generic;

    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
        }

        [HttpGet]
        public IActionResult<HashSet<GameHomePageViewModel>> Index(HttpResponse response, HttpRequest request, HttpSession session)
        {
            if (!this.service.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/user/login");
                return null;
            }
            
            var getParams = request.Url
                .Split('?');

            var filter = getParams.Length == 2 ? getParams[1].Split('=')[1] : string.Empty;

            HashSet<GameHomePageViewModel> games = this.service.GetAllGames(filter, session.Id);

            return this.View(games);
        }
    }
}
