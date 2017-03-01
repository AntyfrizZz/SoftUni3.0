namespace SimpleMVC.App.Views.Home
{
    using System.IO;
    using MVC.Interfaces;

    public class Site : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/home.html");
        }
    }
}