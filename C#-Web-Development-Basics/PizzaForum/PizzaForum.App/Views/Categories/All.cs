using System;
using PizzaForum.App.ViewModels;
using PizzaForum.Common;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace PizzaForum.App.Views.Categories
{
    public class All : IRenderable<AllViewModel>
    {
        public AllViewModel Model { get; set; }

        public string Render()
        {
            var header = ViewBuilder.ReadFile(GlobalConstants.Header);
            var navigation = ViewBuilder.ReadFile(GlobalConstants.NavLogged);
            var nav = string.Format(navigation, ViewBag.Bag["username"]);
            var adminCategories = ViewBuilder.ReadFile(GlobalConstants.AdminCategories);
            var categories = string.Format(adminCategories, this.Model);
            var footer = ViewBuilder.ReadFile(GlobalConstants.Footer);

            return ViewBuilder.CreateView(header, nav, categories, footer);
        }
    }
}
