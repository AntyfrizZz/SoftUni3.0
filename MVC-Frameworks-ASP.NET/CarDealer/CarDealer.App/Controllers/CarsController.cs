namespace CarDealer.App.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Data.Services;
    using Models.BindingModels.Cars;
    using Models.EntityModels;
    using Models.ViewModels.Cars;
    using Security;

    [RoutePrefix("cars")]
    public class CarsController : Controller
    {
        private CarsService service;

        public CarsController()
        {
            this.service = new CarsService();
        }

        [HttpGet]
        [Route("{make?}")]
        public ActionResult All(string make)
        {
            IEnumerable<CarVm> modelCarVms = this.service.GetCarsFromGivenMakeInOrder(make);
            return this.View(modelCarVms);
        }

        [HttpGet]
        [Route("{id:int}/parts")]
        public ActionResult About(int id)
        {
            AboutCarVm vm = this.service.GetCarWithParts(id);

            return this.View(vm);
        }

        [HttpGet]
        [Route("add")]
        public ActionResult Add()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            return this.View();
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add(AddCarBm bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            if (this.ModelState.IsValid)
            {
                User user = AuthenticationManager.GetAuthenticatedUser(httpCookie.Value);
                this.service.AddCar(bind, user.Id);

                return this.RedirectToAction("All");
            }

            return this.View();
        }
    }
}