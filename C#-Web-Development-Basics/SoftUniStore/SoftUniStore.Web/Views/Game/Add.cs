namespace SoftUniStore.Web.Views.Game
{
    using Common;
    using SimpleMVC.Interfaces;

    public class Add : IRenderable
    {
        public string Render()
        {
            var header = ViewBuilder.ReadFile(GlobalConstants.Header);
            var nav = ViewBuilder.ReadFile(GlobalConstants.NavLogged);
            var body = ViewBuilder.ReadFile(GlobalConstants.AddGame);
            var footer = ViewBuilder.ReadFile(GlobalConstants.Footer);

            return ViewBuilder.CreateView(header, nav, body, footer);
        }
    }
}
