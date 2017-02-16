namespace SimpleMVC.App.MVC.Routers
{
    using Interfaces;
    using SimpleHttpServer.Models;
    using System.Collections.Generic;

    public class ControllerRouter : IHandleable
    {
        private IDictionary<string, string> getParams;
        private IDictionary<string, string> postParams;
        private string requestMethod;
        private string controllerName;
        private string actionName;
        private object[] methodParams;

        public HttpResponse Handle(HttpRequest request)
        {
            this.HandleGetParameters(request);
            this.HandlePostParameters(request);
            this.requestMethod = request.Method.ToString();
            this.HandleUrl(request);
        }

        private void HandleGetParameters(HttpRequest request)
        {
            var getParameters = request.Url.Split('?')[1];
            var getTokens = getParameters.Split(new char[] { '=', '&' });

            for (int i = 0; i < getTokens.Length; i += 2)
            {
                this.getParams.Add(getTokens[i], getTokens[i + 1]);
            }
        }

        private void HandlePostParameters(HttpRequest request)
        {
            var postParameters = request.Content.Split(new char[] { '=', '&' });

            for (int i = 0; i < postParameters.Length; i += 2)
            {
                this.postParams.Add(postParameters[i], postParameters[i + 1]);
            }
        }

        private void HandleUrl(HttpRequest request)
        {
            var urlTokens = request.Url.Split('/');

            if (urlTokens.Length == 3)
            {
                this.controllerName = $"{urlTokens[1].Substring(0, 1).ToUpper()}{urlTokens[1].Substring(1).ToLower()}Controller";
                string actionName = urlTokens[2].Split('?')[0];
                this.actionName = actionName.Substring(0, 1).ToUpper() + actionName.Substring(1).ToLower();
            }
        }
    }
}
