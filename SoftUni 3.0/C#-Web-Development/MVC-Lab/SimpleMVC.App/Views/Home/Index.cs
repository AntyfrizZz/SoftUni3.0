namespace SimpleMVC.App.Views.Home
{
    using System.Text;
    using MVC.Interfaces;

    public class Index : IRenderable
    {
        public string Render()
        {
            return "<h3>Hello MVC!</h3>";
        }
    }
}