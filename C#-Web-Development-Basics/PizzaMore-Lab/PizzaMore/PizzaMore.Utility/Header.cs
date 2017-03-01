using System;
using System.Text;

namespace PizzaMore.Utility
{
    public class Header
    {
        private string type;
        private string location;
        private ICookieCollection cookies;

        public Header()
        {
            this.type = Constants.DefaultType;
            this.cookies = new CookieCollection();
        }

        public void AddLocation(string location)
        {
            this.location = string.Format(Constants.LocationFormat, location);
        }

        public void AddCookie(Cookie cookie)
        {
            this.cookies.AddCookie(cookie);
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(this.type);

            foreach (var cookie in this.cookies)
            {
                result.AppendLine(string.Format(Constants.SetCookieFormat, cookie));
            }

            if (location != null)
            {
                result.AppendLine(this.location);
            }

            result.AppendLine().AppendLine();

            return result.ToString();
        }
    }
}
