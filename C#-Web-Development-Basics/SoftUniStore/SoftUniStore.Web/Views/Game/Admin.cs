namespace SoftUniStore.Web.Views.Game
{
    using System.Collections.Generic;
    using System.Text;
    using Common;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;

    public class Admin : IRenderable<HashSet<AdminGameViewModel>>
    {
        public HashSet<AdminGameViewModel> Model { get; set; }

        public string Render()
        {
            var header = ViewBuilder.ReadFile(GlobalConstants.Header);
            var nav = ViewBuilder.ReadFile(GlobalConstants.NavLogged);
            var adminGamesPattern = ViewBuilder.ReadFile(GlobalConstants.AdminGames);

            var games = new StringBuilder();
            this.AddGames(games);
            var adminGames = string.Format(adminGamesPattern, games);

            var footer = ViewBuilder.ReadFile(GlobalConstants.Footer);

            return ViewBuilder.CreateView(header, nav, adminGames, footer);
        }

        private void AddGames(StringBuilder games)
        {
            var gamePattern = ViewBuilder.ReadFile(GlobalConstants.AdminGame);

            foreach (var game in this.Model)
            {
                games.Append(string.Format(gamePattern, game.Title, game.Size, game.Price, game.Id));
            }
        }
    }
}
