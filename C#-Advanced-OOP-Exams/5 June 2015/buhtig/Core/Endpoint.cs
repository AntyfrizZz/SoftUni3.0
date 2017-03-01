namespace Buhtig.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    public class Endpoint : IEndpoint
    {
        private const char CommandNameSpliter = '?';
        private const char CommandArgsSpliter = '&';
        private const char CommandArgsInnerSpliter = '=';

        public Endpoint(string command)
        {
            var commandInfo = command.Split(CommandNameSpliter);
            this.ActionName = commandInfo[0];

            if (commandInfo.Length == 1)
            {
                return;
            }

            var pairs = commandInfo[1]
                .Split(CommandArgsSpliter)
                .Select(x => x.Split(CommandArgsInnerSpliter).Select(WebUtility.UrlDecode).ToArray());

            var parameters = pairs.ToDictionary(pair => pair[0], pair => pair[1]);

            this.ActionParameters = parameters;
        }

        public string ActionName { get; }

        public IDictionary<string, string> ActionParameters { get; }
    }
}
