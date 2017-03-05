namespace SoftUniStore.Web.Views.User
{
    using Common;
    using SimpleMVC.Interfaces;

    public class Login : IRenderable
    {
        public string Render()
        {
            var header = ViewBuilder.ReadFile(GlobalConstants.Header);
            var nav = ViewBuilder.ReadFile(GlobalConstants.NavNotLogged);
            var login = ViewBuilder.ReadFile(GlobalConstants.Login);
            var footer = ViewBuilder.ReadFile(GlobalConstants.Footer);

            return ViewBuilder.CreateView(header, nav, login, footer);
        }
    }
}
