namespace SoftUniStore.Web.Views.Game
{
    using Common;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;

    public class Details : IRenderable<GameDetailsViewModel>
    {
        public GameDetailsViewModel Model { get; set; }

        public string Render()
        {
            var header = ViewBuilder.ReadFile(GlobalConstants.Header);
            var nav = ViewBuilder.ReadFile(GlobalConstants.NavLogged);
            
            var detailsPattern = ViewBuilder.ReadFile(GlobalConstants.GameDetails);
            var details = string.Format(
                detailsPattern, 
                this.Model.Title, 
                this.Model.Trailer, 
                this.Model.Description, 
                this.Model.Price, 
                this.Model.Size, 
                this.Model.ReleaseDate,
                this.Model.Id);

            var footer = ViewBuilder.ReadFile(GlobalConstants.Footer);

            return ViewBuilder.CreateView(header, nav, details, footer);
        }
    }
}
