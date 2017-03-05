namespace SoftUniStore.Web.Views.Home
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Common;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;

    public class Index : IRenderable<HashSet<GameHomePageViewModel>>
    {
        public HashSet<GameHomePageViewModel> Model { get; set; }

        public string Render()
        {
            var header = ViewBuilder.ReadFile(GlobalConstants.Header);
            var nav = ViewBuilder.ReadFile(GlobalConstants.NavLogged);
            var home = ViewBuilder.ReadFile(GlobalConstants.Home);

            var cards = new StringBuilder();
            this.GenerateCards(cards);

            var homeWithCards = string.Format(home, cards);
            var footer = ViewBuilder.ReadFile(GlobalConstants.Footer);

            return ViewBuilder.CreateView(header, nav, homeWithCards, footer);
        }

        private void GenerateCards(StringBuilder cards)
        {
            var counter = 0;
            var closed = true;

            foreach (var game in this.Model)
            {
                if (counter % 3 == 0)
                {
                    cards.Append("<div class=\"card-group\">");
                    closed = false;
                }

                var cardTemplate = ViewBuilder.ReadFile(GlobalConstants.GameCard);
                var card = string.Format(
                    cardTemplate, 
                    game.ImageThumbnail, 
                    game.Title, 
                    game.Price, 
                    game.Size, 
                    game.Description.Substring(0, Math.Min(game.Description.Length, 300)), game.Id);

                cards.Append(card);
                counter++;

                if (counter % 3 == 0)
                {
                    cards.Append("</div>");
                    closed = true;
                }             
            }

            if (!closed)
            {
                cards.Append("</div>");
            }            
        }
    }
}
