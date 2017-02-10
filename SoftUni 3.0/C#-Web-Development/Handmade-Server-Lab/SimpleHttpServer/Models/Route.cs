using SimpleHttpServer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpServer.Models
{
    public class Route
    {
        private string name;
        private string urlRegex;
        private RequestMethod method;
        public Func<HttpRequest, HttpResponse> Callable;


    }
}
