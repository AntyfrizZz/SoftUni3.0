using IssueTracker.Common;
using SimpleMVC.Interfaces;

namespace IssueTracker.Web.Views.Users
{
    public class Login : IRenderable
    {
        public string Render()
        {
            var header = ViewBuilder.ReadFile(GlobalConstants.Header);
            var menu = ViewBuilder.ReadFile(GlobalConstants.Menu);
            var login = ViewBuilder.ReadFile(GlobalConstants.Login);
            var footer = ViewBuilder.ReadFile(GlobalConstants.Footer);

            return ViewBuilder.CreateView(header, menu, login, footer);
        }
    }
}
