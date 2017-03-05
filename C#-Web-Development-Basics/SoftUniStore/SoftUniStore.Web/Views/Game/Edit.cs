namespace SoftUniStore.Web.Views.Game
{
    using Common;
    using Models.BindingModels;
    using SimpleMVC.Interfaces.Generic;

    public class Edit : IRenderable<GameBindingModel>
    {
        public GameBindingModel Model { get; set; }

        public string Render()
        {
            var header = ViewBuilder.ReadFile(GlobalConstants.Header);
            var nav = ViewBuilder.ReadFile(GlobalConstants.NavLogged);

            var editPattern = ViewBuilder.ReadFile(GlobalConstants.EditGame);
            var edit = string.Format(editPattern, this.Model.Title, this.Model.Description, this.Model.ImageThumbnail, this.Model.Price, this.Model.Size, this.Model.Trailer);

            var footer = ViewBuilder.ReadFile(GlobalConstants.Footer);

            return ViewBuilder.CreateView(header, nav, edit, footer);
        }
    }
}
