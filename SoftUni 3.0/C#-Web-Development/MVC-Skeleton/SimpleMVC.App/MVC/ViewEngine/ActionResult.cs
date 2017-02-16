namespace SimpleMVC.App.MVC.ViewEngine
{
    using System;
    using Interfaces;

    public class ActionResult : IActionResult
    {
        public ActionResult(string viewFullQualifiedName)
        {
            this.Action = (IRenderable)Activator
                .CreateInstance(Type.GetType(viewFullQualifiedName));
        }

        public IRenderable Action { get; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}
