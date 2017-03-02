namespace PizzaForum.Common
{
    public static class GlobalConstants
    {
        // DB
        public const int UsernameMinLength = 3;
        public const string UsernamePattern = @"\b[a-z0-9]{3,}\b";
        public const string EmailPattern = @"@";
        public const int PasswordLength = 4;
        public const string PasswordPattern = @"\b[0-9]{4}\b";
        public const int StringMaxLength = 450;

        // Paths
        public const string ContentPath = "../../content/";
        public const string HTML = ".html";
        public const string Header = "header";
        public const string Footer = "footer";
        public const string NavNotLogged = "nav-not-logged";
        public const string NavLogged = "nav-logged";
        public const string Register = "register";
        public const string Login = "login";

    }
}
