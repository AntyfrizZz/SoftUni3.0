
namespace PizzaForum.ConsoleApp
{
    using PizzaForum.App;
    using SimpleHttpServer;
    using SimpleMVC;

    class Startup
    {
        static void Main()
        {
            var server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "PizzaForum.App");
        }
    }
}
