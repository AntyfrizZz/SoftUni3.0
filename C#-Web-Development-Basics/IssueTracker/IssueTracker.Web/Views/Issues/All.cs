using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Common;
using SimpleMVC.Interfaces;

namespace IssueTracker.Web.Views.Issues
{
    public class All : IRenderable
    {
        public string Render()
        {
            var header = ViewBuilder.ReadFile(GlobalConstants.Header);

            var username = ViewBag.GetUserName();

            var withUsername = ViewBuilder.ReadFile(GlobalConstants.MenuLogged);
            var menu = string.Format(withUsername, username);


            var issue = ViewBuilder.ReadFile(GlobalConstants.Issues);
            var footer = ViewBuilder.ReadFile(GlobalConstants.Footer);

            return ViewBuilder.CreateView(header, menu, issue, footer);
        }
    }
}
