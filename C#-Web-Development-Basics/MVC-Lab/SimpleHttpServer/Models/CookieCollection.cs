namespace SimpleHttpServer.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class CookieCollection : IEnumerable<Cookie>
    {
        private IDictionary<string, Cookie> cookies;

        public CookieCollection()
        {
            this.cookies = new Dictionary<string, Cookie>();
        }        

        public int Count => this.cookies.Count;

        public Cookie this[string cookieName]
        {
            get
            {
                return this.cookies[cookieName];
            }

            set
            {
                if (this.Contains(cookieName))
                {
                    this.cookies[cookieName] = value;
                }
                else
                {
                    this.Add(value);
                }
            }
        }

        public bool Contains(string cookieName) => this.cookies.ContainsKey(cookieName);

        public void Add(Cookie cookie)
        {
            if (!this.Contains(cookie.Name))
            {
                this.cookies.Add(cookie.Name, cookie);
            }
            else
            {
                this.cookies[cookie.Name] = cookie;
            }            
        }

        public IEnumerator<Cookie> GetEnumerator() => this.cookies.Values.GetEnumerator();
  
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator(); 

        public override string ToString() => string.Join("; ", this.cookies.Values);
    }
}