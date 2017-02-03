using ProductDelivery.Data;
using System;
using System.IO;
using System.Text;
using ProductsDelivery.Models;

namespace edit_order
{
    public class Startup
    {
        static void Main()
        {
            var db = new ProductsDbCondext();
                        
            var query = Environment.GetEnvironmentVariable("QUERY_STRING");
            var id = int.Parse(query.Split('=')[1]);

            var entity = db.Orders.Find(id);

            var result = new StringBuilder();

            result
                .AppendLine(File.ReadAllText("Html/header.txt"))
                .AppendLine("<body>")
                .AppendLine("<div class=\"container\">")
                .AppendLine("<button class=\"btn btn-toolbar\" onclick=\"goBack()\">Back to Orders</button>")
                .AppendLine("<h4 class=\"text-muted\">Edit Orders</h4>");


            AddContent(result, entity);

            result
                .AppendLine("</div>")
                .AppendLine("<script>")
                .AppendLine("function goBack() {")
                .AppendLine("window.history.back();")
                .AppendLine("}")
                .AppendLine("</script>")   
                .AppendLine("</body>")
                .AppendLine("</html>");

            Console.WriteLine("Content-type:text/html\r\n");
            Console.WriteLine(result);
        }

        private static void AddContent(StringBuilder result, Order entity)
        {
            result
                .AppendLine("<form class=\"form-inline\" action=\"edit-order.exe\" method=\"POST\">")
                .AppendLine("<div class=\"form-group\">");

            result
                .AppendLine(AddInputLine("ID", entity.Id.ToString()))
                .AppendLine("<br>")
                .AppendLine(AddInputLine("Name", entity.Name))
                .AppendLine("<br>")
                .AppendLine(AddInputLine("Type", entity.ProductType))
                .AppendLine("<br>")
                .AppendLine(AddInputLine("Payment Date", entity.PaymentDate.ToString()))
                .AppendLine("<br>")
                .AppendLine(AddInputLine("Delivery Date", entity.DeliveryDate.ToString()))
                .AppendLine("<br>");

            result
                .AppendLine("<button class=\"btn btn-primary\" type=\"submit\">Edit</button>");

            result
                .AppendLine("</form>")
                .AppendLine("</div>");
        }

        private static string AddInputLine(string label, string entityValue)
        {
            var result = new StringBuilder();

            result
                .AppendLine("<div class=\"input-group\">")
                .AppendLine($"<span class=\"input-group-addon\">{label}: </span>")
                .AppendLine($"<input type=\"text\" class=\"form-control\" readonly value=\"{entityValue}\">")
                .Append("</div>");

            return result.ToString();
        }
    }
}
