namespace SimpleMVC.App.MVC.Attributes.Methods
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod) => requestMethod.ToUpper() == "POST";
    }
}