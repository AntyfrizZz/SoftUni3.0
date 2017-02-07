using PizzaMore.Data;
using PizzaMore.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace PizzaMore.Utility
{
    public static class WebUtil
    {
        public static bool IsPost()
        {
            return Environment.GetEnvironmentVariable(Constants.RequestMethod).ToUpper() == Constants.Post;
        }

        public static bool IsGet()
        {
            return Environment.GetEnvironmentVariable(Constants.RequestMethod).ToUpper() == Constants.Get;
        }

        public static IDictionary<string, string> RetrievePostParameters()
        {
            var queryString = WebUtility.UrlDecode(Console.ReadLine());
            return RetrieveRequestParameters(queryString);
        }

        public static IDictionary<string, string> RetrieveGetParameters()
        {
            var queryString = WebUtility.UrlDecode(Environment.GetEnvironmentVariable(Constants.QueryString));
            return RetrieveRequestParameters(queryString);            
        }

        public static ICookieCollection GetCookies()
        {
            var cookies = Environment.GetEnvironmentVariable(Constants.Cookie);

            return RetrieveCookies(cookies);
        }

        public static Session GetSession()
        {
            var cookies = GetCookies();

            if (cookies.ContainsKey(Constants.SID))
            {
                var db = new PizzaMoreDbContext();

                var sessionID = int.Parse(cookies[Constants.SID].Value);
                var session = db.Sessions.FirstOrDefault(s => s.Id == sessionID);

                if (session == null)
                {
                    throw new InvalidOperationException(string.Format(Constants.InexistingSession, sessionID));
                }

                return session;
            }

            return null;
        }

        public static void PrintFileContent(string path)
        {
            string text = File.ReadAllText(path);

            Console.WriteLine(text);
        }

        public static void PageNotAllowed()
        {
            PrintFileContent(Constants.Index);
        }

        private static ICookieCollection RetrieveCookies(string cookies)
        {
            var result = new CookieCollection();

            var tokens = cookies.Split(';');

            foreach (var pair in tokens)
            {
                var kvp = pair.Split('=');
                var cookie = new Cookie(kvp[0], kvp[1]);

                result.AddCookie(cookie);
            }

            return result;
        }

        private static IDictionary<string, string> RetrieveRequestParameters(string queryString)
        {
            var result = new Dictionary<string, string>();

            var tokens = queryString.Split('&');

            foreach (var pair in tokens)
            {
                var kvp = pair.Split('=');
                result.Add(kvp[0], kvp[1]);
            }

            return result;
        }        
    }
}
