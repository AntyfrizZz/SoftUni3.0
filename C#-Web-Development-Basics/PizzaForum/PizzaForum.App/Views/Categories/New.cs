using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaForum.Common;
using SimpleMVC.Interfaces;

namespace PizzaForum.App.Views.Categories
{
    public class New : IRenderable
    {
        public string Render()
        {
            var header = ViewBuilder.ReadFile(GlobalConstants.Header);
            var navigation = ViewBuilder.ReadFile(GlobalConstants.NavLogged);
            var nav = string.Format(navigation, ViewBag.Bag["username"]);
            var category = ViewBuilder.ReadFile(GlobalConstants.AdminCategory);
            var footer = ViewBuilder.ReadFile(GlobalConstants.Footer);

            return ViewBuilder.CreateView(header, nav, category, footer);
        }
    }
}
