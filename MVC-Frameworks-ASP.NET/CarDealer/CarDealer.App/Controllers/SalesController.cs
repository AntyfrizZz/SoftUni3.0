﻿namespace CarDealer.App.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Data.Services;
    using Models.BindingModels.Sales;
    using Models.EntityModels;
    using Models.ViewModels.Sales;
    using Security;

    [RoutePrefix("sales")]
    public class SalesController : Controller
    {
        private SalesService service;

        public SalesController()
        {
            this.service = new SalesService();
        }

        [HttpGet]
        [Route]
        public ActionResult All()
        {
            IEnumerable<SaleVm> vms = this.service.GetAllSales();
            return this.View(vms);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult About(int id)
        {
            SaleVm saleVm = this.service.GetSale(id);

            return this.View(saleVm);
        }

        [HttpGet]
        [Route("discounted/{percent?}/")]
        public ActionResult Discounted(double? percent)
        {
            IEnumerable<SaleVm> sales = this.service.GetDiscountedSales(percent);
            return this.View(sales);
        }

        [HttpGet]
        [Route("add/")]
        public ActionResult Add()
        {
            var cookie = this.Request.Cookies.Get("sessionId");

            if (cookie == null || !AuthenticationManager.IsAuthenticated(cookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            AddSaleVm vm = this.service.GetSalesVm();
            return this.View(vm);
        }

        [HttpPost]
        [Route("add/")]
        public ActionResult Add([Bind(Include = "CustomerId, CarId, Discount")] AddSaleBm bind)
        {
            if (this.ModelState.IsValid)
            {
                AddSaleConfirmationVm confirmationVm = this.service.GetSaleCofirmationVm(bind);
                return this.RedirectToAction("AddConfirmation", confirmationVm);
            }

            AddSaleVm addSaleVm = this.service.GetSalesVm();
            return this.View(addSaleVm);
        }

        [HttpGet]
        [Route("AddConfirmation")]
        public ActionResult AddConfirmation(AddSaleConfirmationVm vm)
        {
            var cookie = this.Request.Cookies.Get("sessionId");
            if (cookie == null || !AuthenticationManager.IsAuthenticated(cookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            return this.View(vm);
        }

        [HttpPost]
        [Route("AddConfirmation")]
        public ActionResult AddConfirmation(AddSaleBm bind)
        {
            var cookie = this.Request.Cookies.Get("sessionId");
            if (cookie == null || !AuthenticationManager.IsAuthenticated(cookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            User user = AuthenticationManager.GetAuthenticatedUser(cookie.Value);

            this.service.AddSale(bind, user.Id);
            return this.RedirectToAction("All");
        }
    }
}