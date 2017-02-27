namespace SimpleMVC.App.MVC.ViewEngine
{
    using System;
    using Interfaces;

    public class ActionResult : IActionResult
    {
        public ActionResult(string viewFullQualifedName)
        {
            this.Action = (IRenderable)Activator
                .CreateInstance(Type.GetType(viewFullQualifedName));
        }

        public IRenderable Action { get; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}
