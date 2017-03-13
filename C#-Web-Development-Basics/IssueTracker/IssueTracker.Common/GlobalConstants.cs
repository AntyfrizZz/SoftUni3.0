using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Common
{
    public class GlobalConstants
    {
        // Paths
        public const string ContentPath = "../../content/";
        public const string HTML = ".html";
        public const string Header = "header";
        public const string Menu = "menu";
        public const string Login = "login";
        public const string Footer = "footer";
        public const string Register = "register";
        public const string Alert = "alert";
        public const string MenuLogged = "menu-logged";
        public const string Home = "home";
        public const string Issues = "issues";

        // Error messages
        public const string UsernameError = "The username should be between 5 and 30 symbols";
        public const string PasswordError = "The password is not in correct format";
        public const string FullnameError = "The full name should be at least 5 symbols";
        public const string ConfirmPasswordError = "Passwords does not match";

    }
}
