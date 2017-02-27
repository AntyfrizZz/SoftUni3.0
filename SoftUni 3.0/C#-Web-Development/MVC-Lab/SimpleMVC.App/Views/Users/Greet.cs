namespace SimpleMVC.App.Views.Users
{
    using MVC.Interfaces.Generic;
    using ViewModels;

    public class Greet : IRenderable<GreetViewModel>
    {
        public GreetViewModel Model { get; set; }

        public string Render() => $"Hello user with session id: {this.Model.SessionId}";
    }
}
