namespace Buhtig.Core
{
    using System;

    public class Engine : IEngine
    {
        private readonly IDispatcher dispatcher;

        public Engine(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public Engine()
            : this(new Dispatcher())
        {
        }

        public void Run()
        {
            while (true)
            {
                string url = Console.ReadLine();

                if (url == null)
                {
                    break;
                }

                url = url.Trim();

                if (!string.IsNullOrEmpty(url))
                {
                    try
                    {
                        var endpoint = new Endpoint(url);
                        string viewResult = this.dispatcher.DispatchAction(endpoint);
                        Console.WriteLine(viewResult);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine(ioe.Message);
                    }
                }
            }
        }
    }
}
