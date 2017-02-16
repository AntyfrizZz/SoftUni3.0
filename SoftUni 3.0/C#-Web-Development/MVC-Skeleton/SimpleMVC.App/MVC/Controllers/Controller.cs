namespace SimpleMVC.App.MVC.Controllers
{
    using MVC;
    using Interfaces.Generic;
    using ViewEngine;
    using ViewEngine.Generic;
    using Interfaces;
    using System.Runtime.CompilerServices;

    public class Controller
    {
        protected IActionResult View([CallerMemberName]string callee = "")
        {
            string controllerName = this.GetType()
                .Name
                .Replace(MvcContext.Current.ControllersSuffix, string.Empty);

            string fullQualifierName = $"{MvcContext.Current.AssemblyName}.{MvcContext.Current.ViewsFolder}.{controllerName}.{callee}";

            return new ActionResult(fullQualifierName);
        }

        protected IActionResult View(string controller, string action)
        {
            string fullQualifierName = $"{MvcContext.Current.AssemblyName}.{MvcContext.Current.ViewsFolder}.{controller}.{action}";

            return new ActionResult(fullQualifierName);
        }

        protected IActionResult<T> View<T>([CallerMemberName]string callee = "", T model)
        {
            string controllerName = this.GetType()
                .Name
                .Replace(MvcContext.Current.ControllersSuffix, string.Empty);

            string fullQualifierName = $"{MvcContext.Current.AssemblyName}.{MvcContext.Current.ViewsFolder}.{controllerName}.{callee}";

            return new ActionResult<T>(fullQualifierName, model);
        }

        protected IActionResult<T> View<T>(string controller, string action, T model)
        {
            string fullQualifierName = $"{MvcContext.Current.AssemblyName}.{MvcContext.Current.ViewsFolder}.{controller}.{action}";

            return new ActionResult<T>(fullQualifierName, model);
        }

    }
}
