using PizzaForum.App.BindingModels;
using PizzaForum.App.Services;
using PizzaForum.App.ViewModels;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace PizzaForum.App.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoriesService service;

        public CategoriesController()
        {
            this.service = new CategoriesService();
        }

        [HttpGet]
        public IActionResult<AllViewModel> All(HttpSession session, HttpResponse response)
        {
            if (!this.service.IsAutenticated(session.Id))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            var user = this.service.GetAutenticatedUser(session.Id);

            if (!user.IsAdmin)
            {
                this.Redirect(response, "/home/topics");
            }

            var viewModel = this.service.GetAllViewModel(user);
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult New(HttpResponse response, HttpSession session)
        {
            if (!this.service.IsAutenticated(session.Id))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            var user = this.service.GetAutenticatedUser(session.Id);

            if (!user.IsAdmin)
            {
                this.Redirect(response, "/home/topics");
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult New(HttpResponse response, HttpSession session, NewCategoryBindingModel model)
        {
            if (!this.service.IsAutenticated(session.Id))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            var user = this.service.GetAutenticatedUser(session.Id);

            if (!user.IsAdmin)
            {
                this.Redirect(response, "/home/topics");
            }

            if (this.service.IsNewCategoryValid(model))
            {
                this.Redirect(response, "/categories/new");
                return null;
            }

            this.service.AddNewCategory(model);
            this.Redirect(response, "/categories/all");
            return null;
        }

        [HttpGet]
        public IActionResult Delete(HttpRequest response, HttpSession session, int id)
        {

        }
    }
}
