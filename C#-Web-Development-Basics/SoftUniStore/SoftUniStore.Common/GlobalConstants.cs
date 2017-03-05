namespace SoftUniStore.Common
{
    public static class GlobalConstants
    {
        // Paths
        public const string ContentPath = "../../content/";
        public const string HTML = ".html";
        public const string AddGame = "add-game";
        public const string AdminGames = "admin-games";
        public const string AdminGame = "admin-game";
        public const string DeleteGame = "delete-game";
        public const string EditGame = "edit-game";
        public const string Footer = "footer";
        public const string GameDetails = "game-details";
        public const string Header = "header";
        public const string Home = "home";
        public const string Login = "login";
        public const string NavLogged = "nav-logged";
        public const string NavNotLogged = "nav-not-logged";
        public const string Register = "register";
        public const string GameCard = "game-card";

        // Models
        public const int PasswordMinLength = 6;
        public const int TitleMinLength = 3;
        public const int TitleMaxLength = 100;
        public const string ImageLinkPattern = @"\bhttp(s)*:\/\/";
        public const int DescriptionMinLength = 20;


    }
}
