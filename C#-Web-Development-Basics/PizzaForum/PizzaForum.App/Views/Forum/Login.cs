using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaForum.Common;
using SimpleMVC.Interfaces;

namespace PizzaForum.App.Views.Forum
{
    public class Login : IRenderable
    {
        public string Render()
        {
            var header = ViewBuilder.ReadFile(GlobalConstants.Header);
            var navigation = ViewBuilder.ReadFile(GlobalConstants.NavNotLogged);
            var login = ViewBuilder.ReadFile(GlobalConstants.Login);
            var footer = ViewBuilder.ReadFile(GlobalConstants.Footer);

            return ViewBuilder.CreateView(header, navigation, login, footer);
        }
    }
}
