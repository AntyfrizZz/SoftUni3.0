using SimpleHttpServer.Enums;
using System.Text;

namespace SimpleHttpServer.Models
{
    public class HttpRequest
    {
        private RequestMethod method;
        private string url;
        private Header header;

        public HttpRequest(RequestMethod method, string url, Header header)
        {
            this.method = method;
            this.url = url;
            this.header = header;
        }

        public string ContentLength { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result
                .AppendLine($"{this.method} {this.url}")
                .AppendLine(this.header.ToString());

            if (!string.IsNullOrWhiteSpace(this.ContentLength))
            {
                result.AppendLine($"Content-Length: {this.ContentLength}");
            }

            return base.ToString();
        }

    }
}
