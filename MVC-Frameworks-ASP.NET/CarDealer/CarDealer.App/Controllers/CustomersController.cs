﻿namespace CarDealer.App.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Data.Services;
    using Models.BindingModels.Customers;
    using Models.ViewModels.Customers;

    [RoutePrefix("customers")]
    public class CustomersController : Controller
    {
        private CustomersService service;

        public CustomersController()
        {
            this.service = new CustomersService();
        }

        [HttpGet]
        [Route("all/{order:regex(ascending|descending)}")]
        public ActionResult All(string order)
        {
            IEnumerable<AllCustomerVm> viewModels = this.service.GetAllOrderedCustomers(order);
            return this.View(viewModels);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult About(int id)
        {
            AboutCustomerVm vm = this.service.GetCustomerWithCarData(id);

            return this.View(vm);
        }

        [HttpGet]
        [Route("add")]
        public ActionResult Add() => this.View();

        [HttpPost]
        [Route("add")]
        public ActionResult Add(AddCustomerBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddCustomer(bind);

                return this.RedirectToAction("All", new { order = "ascending" });
            }

            return this.View();
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            EditCustomerVm vm = this.service.GetEditVm(id);

            return this.View(vm);
        }

        [HttpPost]
        [Route("edit/{id}")]
        public ActionResult Edit(EditCustomerBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditCustomer(bind);
                return this.RedirectToAction("All", new { order = "ascending" });
            }

            return this.View(this.service.GetEditVm(bind.Id));
        }
    }
}