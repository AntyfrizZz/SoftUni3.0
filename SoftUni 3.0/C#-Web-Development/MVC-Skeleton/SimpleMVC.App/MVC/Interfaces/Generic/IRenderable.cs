namespace SimpleMVC.App.MVC.Interfaces.Generic
{
    public interface IRenderable<T>
    {
        string Render();

        T Model { get; set; }
    }
}
