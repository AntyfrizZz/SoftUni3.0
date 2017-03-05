namespace SoftUniStore.Web.Controllers
{
    using System.Collections.Generic;
    using Data.Services;
    using Models.BindingModels;
    using Models.ViewModels;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;

    public class GameController : Controller
    {
        private GameService service;

        public GameController()
        {
            this.service = new GameService();
        }

        [HttpGet]
        public IActionResult<GameDetailsViewModel> Details(HttpRequest request, HttpSession session, HttpResponse response)
        {
            if (!this.service.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/user/login");
                return null;
            }

            var id = int.Parse(request.Url
                .Split('?')[1]
                .Split('=')[1]);

            GameDetailsViewModel gameDetails = this.service.GetGameDetails(id);

            return this.View(gameDetails);
        }

        [HttpPost]
        public void Buy(HttpResponse response, GameIdBindingModel model, HttpSession session)
        {
            this.service.BuyGame(session.Id, model);
            this.Redirect(response, "/home/index?filter=owned");
        }

        [HttpGet]
        public IActionResult<HashSet<AdminGameViewModel>> Admin(HttpSession session, HttpResponse response)
        {
            if (!this.service.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/user/login");
                return null;
            }

            if (!this.service.IsAdmin(session.Id))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            HashSet<AdminGameViewModel> games = this.service.GetAllAdminGames();

            return this.View(games);
        }

        [HttpGet]
        public IActionResult Add(HttpSession session, HttpResponse response)
        {
            if (!this.service.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/user/login");
                return null;
            }

            if (!this.service.IsAdmin(session.Id))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Add(HttpResponse response, GameBindingModel model)
        {
            if (!this.service.IsGameModelValid(model))
            {
                return this.View();
            }

            this.service.AddGame(model);

            this.Redirect(response, "/game/admin");
            return null;
        }

        [HttpGet]
        public IActionResult<GameBindingModel> Edit(HttpRequest request, HttpSession session, HttpResponse response)
        {
            if (!this.service.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/user/login");
                return null;
            }

            if (!this.service.IsAdmin(session.Id))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            var id = int.Parse(request.Url
                .Split('?')[1]
                .Split('=')[1]);

            GameBindingModel game = this.service.GetGame(id);

            return this.View(game);
        }

        [HttpPost]
        public IActionResult Edit(HttpRequest request, HttpResponse response, GameBindingModel model)
        {
            if (!this.service.IsGameModelValid(model))
            {
                return this.View();
            }

            var id = int.Parse(request.Url
                .Split('?')[1]
                .Split('=')[1]);

            this.service.UpdateGame(model, id);
            this.Redirect(response, "/game/admin");
            return null;
        }

        [HttpGet]
        public IActionResult<DeleteGameViewModel> Delete(HttpRequest request, HttpSession session, HttpResponse response)
        {
            if (!this.service.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/user/login");
                return null;
            }

            if (!this.service.IsAdmin(session.Id))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            var id = int.Parse(request.Url
                .Split('?')[1]
                .Split('=')[1]);

            DeleteGameViewModel model = this.service.GetGameForDeletion(id);
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Delete(HttpResponse response, GameIdBindingModel model)
        {      
            this.service.DeleteGame(model.Id);

            this.Redirect(response, "/game/admin");
            return null;
        }
    }
}
