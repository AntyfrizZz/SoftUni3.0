using System.Collections.Generic;

namespace PizzaMore.Utility
{
    public interface ICookieCollection : IEnumerable<Cookie>
    {
        int Count { get; }

        Cookie this[string key] { get; set; }

        void AddCookie(Cookie cookie);

        void RemoveCookie(string cookieName);

        bool ContainsKey(string key);
    }
}
