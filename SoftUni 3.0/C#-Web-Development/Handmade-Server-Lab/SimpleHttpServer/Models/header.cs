using SimpleHttpServer.Enums;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SimpleHttpServer.Models
{
    public class Header
    {
        private const string DefaultContentType = "text/html";

        private HeaderType type;
        private string contentType;
        private ICookieCollection cookies;
        private IDictionary<string, string> otherParameters;

        public Header(HeaderType type)
        {
            this.type = type;
            this.contentType = DefaultContentType;
            this.cookies = new CookieCollection();
            this.otherParameters = new Dictionary<string, string>();
        }

        public string ContentLength { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"Content-type: {this.contentType}");

            if (this.cookies.Count > 0)
            {
                if (this.type == HeaderType.HttpRequest)
                {
                    result.AppendLine($"Cookie: {this.cookies.ToString()}");
                }
                else if (this.type == HeaderType.HttpResponse)
                {
                    foreach (var cookie in this.cookies)
                    {
                        result.AppendLine($"Set-Cookie: {cookie}");
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(this.ContentLength))
            {
                result.AppendLine($"Content-Length: {this.ContentLength}");
            }            

            foreach (var parameter in this.otherParameters)
            {
                result.Append($"{parameter.Key}: {parameter.Value}");
            }

            result.AppendLine().AppendLine();

            return result.ToString();
        }
    }
}
