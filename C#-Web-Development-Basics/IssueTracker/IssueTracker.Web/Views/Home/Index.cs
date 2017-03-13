using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Common;
using SimpleMVC.Interfaces;

namespace IssueTracker.Web.Views.Home
{
    public class Index : IRenderable
    {
        public string Render()
        { 
            var header = ViewBuilder.ReadFile(GlobalConstants.Header);

            string menu = null;

            var username = ViewBag.GetUserName();

            if (username == null)
            {
                menu = ViewBuilder.ReadFile(GlobalConstants.Menu);
            }
            else
            {
                var withUsername = ViewBuilder.ReadFile(GlobalConstants.MenuLogged);
                menu = string.Format(withUsername, username);
            }
      
            var home = ViewBuilder.ReadFile(GlobalConstants.Home);
            var footer = ViewBuilder.ReadFile(GlobalConstants.Footer);

            return ViewBuilder.CreateView(header, menu, home, footer);
        }
    }
}
