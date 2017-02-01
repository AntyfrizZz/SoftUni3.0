using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsDelivery.Models
{
    public class Status
    {
        private ICollection<Order> orders;

        public Status()
        {
            this.orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Order> Orders
        {
            get { return this.orders; }
            set { this.orders = value; }
        }
    }
}
