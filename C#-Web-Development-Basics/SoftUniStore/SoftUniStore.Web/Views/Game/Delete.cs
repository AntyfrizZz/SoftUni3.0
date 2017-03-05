namespace SoftUniStore.Web.Views.Game
{
    using Common;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;

    public class Delete : IRenderable<DeleteGameViewModel>
    {
        public DeleteGameViewModel Model { get; set; }

        public string Render()
        {
            var header = ViewBuilder.ReadFile(GlobalConstants.Header);
            var nav = ViewBuilder.ReadFile(GlobalConstants.NavLogged);
            var bodyTemplate = ViewBuilder.ReadFile(GlobalConstants.DeleteGame);
            var body = string.Format(bodyTemplate, this.Model.Title, this.Model.Id);
            var footer = ViewBuilder.ReadFile(GlobalConstants.Footer);

            return ViewBuilder.CreateView(header, nav, body, footer);
        }
    }
}
