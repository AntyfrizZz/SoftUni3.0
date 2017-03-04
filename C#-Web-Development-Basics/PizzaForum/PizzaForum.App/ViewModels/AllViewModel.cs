using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaForum.App.ViewModels
{
    public class AllViewModel
    {
        public IEnumerable<AllCategoriesViewModel> Categories { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var category in this.Categories)
            {
                result.Append(category);
            }

            return result.ToString();
        }
    }    
}
