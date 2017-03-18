namespace CarDealer.App.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Data.Services;
    using Models.BindingModels.Suppliers;
    using Models.EntityModels;
    using Models.ViewModels.Suppliers;
    using Security;

    [RoutePrefix("suppliers")]
    public class SuppliersController : Controller
    {
        private SuppliersService service;

        public SuppliersController()
        {
            this.service = new SuppliersService();
        }

        [HttpGet]
        [Route("{type:regex(local|importers)}")]
        public ActionResult All(string type)
        {
            IEnumerable<SupplierVm> viewModels = this.service.GetAllSuppliersByType(type);
            return this.View(viewModels);
        }

        [HttpGet]
        [Route("add/")]
        public ActionResult Add()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }

            return this.View();
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add(AddSupplierBm bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }

            if (ModelState.IsValid)
            {
                User loggedInUser = AuthenticationManager.GetAuthenticatedUser(httpCookie.Value);

                this.service.AddSupplier(bind, loggedInUser.Id);
                return this.RedirectToAction("All");
            }

            return this.View();
        }

        [HttpGet]
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }

            EditSupplierVm vm = this.service.GetEditSupplierVm(id);
            return this.View(vm);
        }

        [HttpPost]
        [Route("edit/{id:int}")]
        public ActionResult Edit(EditSupplierBm bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }

            if (!this.ModelState.IsValid)
            {
                EditSupplierVm vm = this.service.GetEditSupplierVm(bind.Id);
                return this.View(vm);
            }

            User loggedInUser = AuthenticationManager.GetAuthenticatedUser(httpCookie.Value);

            this.service.EditSupplier(bind, loggedInUser.Id);
            return this.RedirectToAction("All");
        }

        [HttpGet]
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }

            DeleteSuplierVm vm = this.service.GetDeleteSupplierVm(id);
            return this.View(vm);
        }

        [HttpPost]
        [Route("delete/{id:int}")]
        public ActionResult Delete(DeleteSupplierBm bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }

            if (!this.ModelState.IsValid)
            {
                DeleteSuplierVm vm = this.service.GetDeleteSupplierVm(bind.Id);
                return this.View(vm);
            }

            User loggedInUser = AuthenticationManager.GetAuthenticatedUser(httpCookie.Value);

            this.service.DeleteSupplier(bind, loggedInUser.Id);
            return this.RedirectToAction("All");
        }
    }
}