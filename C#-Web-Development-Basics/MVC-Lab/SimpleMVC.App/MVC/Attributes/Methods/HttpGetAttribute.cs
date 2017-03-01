namespace SimpleMVC.App.MVC.Attributes.Methods
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod) => requestMethod.ToUpper() == "GET";
    }
}