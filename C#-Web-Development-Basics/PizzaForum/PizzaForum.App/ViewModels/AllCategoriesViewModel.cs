using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaForum.App.ViewModels
{
    public class AllCategoriesViewModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result
                .Append("<tr>")
                .Append($"<td><a href=\"#\">{this.CategoryName}</a></td>")
                .Append($"<td><a href=\"/categories/edit?id={this.Id}\" class=\"btn btn-primary\">Edit</a></td>")
                .Append($"<td><a href=\"/categories/delete?id={this.Id}\" class=\"btn btn-danger\">Delete</a></td>")
                .Append("</tr>");

            return result.ToString();
        }
    }
}
