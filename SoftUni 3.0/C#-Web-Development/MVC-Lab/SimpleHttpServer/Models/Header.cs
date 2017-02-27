namespace SimpleHttpServer.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Enums;

    public class Header
    {
        private const string DefaultContentType = "text/html";

        public Header(HeaderType type)
        {
            this.Type = type;
            this.ContentType = DefaultContentType;
            this.Cookies = new CookieCollection();
            this.OtherParameters = new Dictionary<string, string>();
        }

        public HeaderType Type { get; set; }

        public string ContentType { get; set; }

        public string ContentLength { get; set; }

        public string Location { get; set; }

        public Dictionary<string, string> OtherParameters { get; }

        public CookieCollection Cookies { get; }

        public void AddCookie(Cookie cookie) => this.Cookies.Add(cookie);

        public override string ToString()
        {
            StringBuilder header = new StringBuilder();

            header.AppendLine($"Content-type: {this.ContentType}");

            if (this.Location != null)
            {
                header.AppendLine($"Location: {this.Location}");
            }

            if (this.Cookies.Count > 0)
            {
                if (this.Type == HeaderType.HttpRequest)
                {
                    header.AppendLine($"Cookie: {this.Cookies.ToString()}");
                }
                else if (this.Type == HeaderType.HttpResponse)
                {
                    foreach (var cookie in this.Cookies)
                    {
                        header.AppendLine($"Set-Cookie: {cookie}");
                    }
                }
            }

            if (this.ContentLength != null)
            {
                header.AppendLine($"Content-Length: {this.ContentLength}");
            }

            foreach (var other in this.OtherParameters)
            {
                header.AppendLine($"{other.Key}: {other.Value}");
            }

            header.AppendLine();

            return header.ToString();
        }
    }
}