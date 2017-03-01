using ProductDelivery.Data;
using ProductsDelivery.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ProductsDelivery.ConsoleApp
{
    public class Startup
    {
        static void Main()
        {
            var db = new ProductsDbCondext();

            var result = new StringBuilder();

            result
                .AppendLine(File.ReadAllText("Html/header.txt"))
                .AppendLine("<body>")
                .AppendLine("<div class=\"container\">")
                .AppendLine("<h4 class=\"text-muted\">Orders</h4>");

            AddOrders(db, result);

            result
                .AppendLine("</div>")
                .AppendLine("</body>")
                .AppendLine("</html>");

            Console.WriteLine("Content-type:text/html\r\n");
            Console.WriteLine(result);
        }

        public static void AddOrders(ProductsDbCondext db, StringBuilder result)
        {
            result.AppendLine("<table class=\"table\">");

            result.AppendLine(File.ReadAllText("Html/table-header-row.txt"));

            result.AppendLine("<tbody>");

            var orders = db.Orders.ToList();

            foreach (var order in orders)
            {
                result.Append("<tr class=\"");

                switch (order.StatusId)
                {
                    case 1:
                        result.Append("bg-info");
                        break;
                    case 2:
                        result.Append("bg-success");
                        break;
                    case 3:
                        result.Append("bg-danger");
                        break;
                    case 4:
                        result.Append("bg-warning");
                        break;
                }

                result.AppendLine("\">");

                result
                    .AppendLine($"<td>{order.Id}</td>")
                    .AppendLine($"<td><strong>{order.Name}</strong> ({order.ProductType})</td>")
                    .AppendLine($"<td>{order.PaymentDate}</td>")
                    .AppendLine($"<td>{order.DeliveryDate}</td>")
                    .AppendLine($"<td>{order.Status.Name}</td>")
                    .AppendLine($"<td><a href=\"edit-order.exe?ID={order.Id}\">Edit</a></td>");


                result.AppendLine("</tr>");
            }

            result
                .AppendLine("</tbody>")
                .AppendLine("</table>");

        }
    }
}
