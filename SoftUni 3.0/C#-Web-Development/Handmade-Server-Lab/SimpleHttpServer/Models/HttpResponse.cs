using System.Net;

namespace SimpleHttpServer.Models
{
    public class HttpResponse
    {
        private HttpStatusCode statusCode;
        private string statusMessage;
        private Header header;
        private byte[] content;
    }
}
