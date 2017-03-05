namespace SoftUniStore.Web
{
    using AutoMapper;
    using Models;
    using Models.BindingModels;
    using Models.ViewModels;
    using SimpleHttpServer;
    using SimpleMVC;

    public class Startup
    {
        public static void Main()
        {
            ConfigureMapper();
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "SoftUniStore.Web");
        }

        private static void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<UserRegisterBindingModel, User>();
                expression.CreateMap<Game, GameHomePageViewModel>();
                expression.CreateMap<Game, GameDetailsViewModel>();
                expression.CreateMap<Game, AdminGameViewModel>();
                expression.CreateMap<GameBindingModel, Game>();
                expression.CreateMap<Game, GameBindingModel>();
                expression.CreateMap<Game, DeleteGameViewModel>();
            });
        }
    }
}
