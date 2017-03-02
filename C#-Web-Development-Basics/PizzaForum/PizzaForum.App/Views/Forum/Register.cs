namespace PizzaForum.App.Views.Forum
{
    using PizzaForum.Common;
    using SimpleMVC.Interfaces;

    public class Register : IRenderable
    {
        public string Render()
        {
            var header = ViewBuilder.ReadFile(GlobalConstants.Header);
            var navigation = ViewBuilder.ReadFile(GlobalConstants.NavNotLogged);
            var register = ViewBuilder.ReadFile(GlobalConstants.Register);
            var footer = ViewBuilder.ReadFile(GlobalConstants.Footer);

            return ViewBuilder.CreateView(header, navigation, register, footer);
        }
    }
}
        