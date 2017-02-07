using System;
using System.Collections;
using System.Collections.Generic;

namespace PizzaMore.Utility
{
    public class CookieCollection : ICookieCollection
    {
        private IDictionary<string, Cookie> cookies;

        public CookieCollection()
        {
            this.cookies = new Dictionary<string, Cookie>();
        }

        public Cookie this[string key]
        {
            get
            {
                return this.cookies[key];
            }

            set
            {
                if (this.cookies.ContainsKey(key))
                {
                    this.cookies[key] = value;
                }
                else
                {
                    this.cookies.Add(key, value);
                }
            }
        }

        public int Count => this.cookies.Count;

        public void AddCookie(Cookie cookie)
        {
            this.cookies.Add(cookie.Name, cookie);
        }

        public bool ContainsKey(string key)
        {
            return this.cookies.ContainsKey(key);
        }

        public IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void RemoveCookie(string cookieName)
        {
            this.cookies.Remove(cookieName);
        }

        IEnumerator<Cookie> IEnumerable<Cookie>.GetEnumerator()
        {
            return this.cookies.Values.GetEnumerator();
        }
    }
}
