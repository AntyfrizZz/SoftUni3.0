namespace SimpleHttpServer.Utilities
{
    using System;
    using Models;

    public static class SessionCreator
    {
        public static HttpSession Create()
        {
            var sessionId = new Random().Next().ToString();
            var session = new HttpSession(sessionId);
            return session;
        }
    }
}