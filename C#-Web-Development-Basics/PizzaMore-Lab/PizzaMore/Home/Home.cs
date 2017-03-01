using PizzaMore.Model;
using PizzaMore.Utility;
using System.Collections.Generic;

namespace Home
{
    public class Home
    {
        private static IDictionary<string, string> RequestParameters;
        private static Session Session;
        private static Header Header;
        private static string Language;

        static void Main()
        {
            Language = Constants.EN;
            AddDefaultLanguageCookie();
        }

        public static void AddDefaultLanguageCookie()
        {
            var cookies = WebUtil.GetCookies();

            if (!cookies.ContainsKey(Constants.Lang))
            {
                var cookie = new Cookie(Constants.Lang, Constants.EN);
                Header.AddCookie(cookie);
            }
        }
    }
}
