namespace SimpleHttpServer.RouteHandlers
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Enums;
    using Models;
    using Utilities;

    public class FileSystemRouteHandler
    {
        public string BasePath { get; set; }

        public HttpRequest Request { get; set; }

        public string RouteUrlRegex { get; set; }

        public HttpResponse Handle(HttpRequest request)
        {
            this.Request = request;
            var urlPart = string.Empty;

            // extract the path if there is one
            var match = Regex.Match(request.Url, this.RouteUrlRegex);

            if (match.Groups.Count > 1)
            {
                urlPart = match.Groups[1].Value;
            }
            else
            {
                urlPart = request.Url;
            }

            urlPart = SanitarizePath(urlPart);

            // make sure the first part of the path is not 
            if (urlPart.Length > 0)
            {
                var firstChar = urlPart.ElementAt(0);
                if (firstChar == '/' || firstChar == '\\')
                {
                    urlPart = "." + urlPart;
                }
            }

            var localPath = Path.Combine(this.BasePath, urlPart);

            if (Directory.Exists(localPath))
            {
                return this.HandleDirectory(localPath);
            }
            else if (File.Exists(localPath))
            {
                return this.HandleFile(localPath);
            }
            else
            {
                return HttpResponseBuilder.NotFound();
            }
        }

        private static string SanitarizePath(string urlPart)
        {
            urlPart = urlPart.Replace("\\..\\", "\\");
            urlPart = urlPart.Replace("/../", "/");
            urlPart = urlPart.Replace("//", "/");
            urlPart = urlPart.Replace(@"\\", @"\");
            urlPart = urlPart.Replace(":", string.Empty);
            urlPart = urlPart.Replace("/", Path.DirectorySeparatorChar.ToString());

            return urlPart;
        }

        private HttpResponse HandleFile(string localPath)
        {
            var fileExtension = Path.GetExtension(localPath);

            var response = new HttpResponse();
            response.Header.ContentType = QuickMimeTypeMapper.GetMimeType(fileExtension);

            response.StatusCode = ResponseStatusCode.Ok;
            response.Content = File.ReadAllBytes(localPath);
            response.Header.ContentLength = response.Content.Length.ToString();

            return response;
        }

        private HttpResponse HandleDirectory(string localPath)
        {
            var output = new StringBuilder();
            output.Append(string.Format($"<h3> Directory: {Request.Url} </h3>"));
            output.Append("<ul>");

            foreach (var folder in Directory.GetDirectories(localPath).OrderBy(d => d))
            {
                var dirInfo = new DirectoryInfo(folder);
                output.Append($"<li><a href=\"{dirInfo.Name}\">{dirInfo.Name}/</a></li>");
            }

            foreach (var entry in Directory.GetFiles(localPath).OrderBy(f => f))
            {
                var fileInfo = new FileInfo(entry);
                output.Append($"<li><a href=\"{fileInfo.Name}\">{fileInfo.Name}</a></li>");
            }

            output.Append("</ul>");

            return new HttpResponse()
            {
                StatusCode = ResponseStatusCode.Ok,
                ContentAsUTF8 = output.ToString(),
            };
        }
    }
}