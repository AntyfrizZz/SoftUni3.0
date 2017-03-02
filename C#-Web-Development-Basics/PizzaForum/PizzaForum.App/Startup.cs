using SimpleHttpServer;
using SimpleMVC;

namespace PizzaForum.App
{
    public class Startup
    {
        static void Main()
        {
            var server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "PizzaForum.App");
        }
    }
}
