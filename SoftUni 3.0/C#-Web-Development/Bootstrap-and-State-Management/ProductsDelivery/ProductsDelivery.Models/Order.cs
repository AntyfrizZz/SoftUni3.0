using System;
using System.ComponentModel.DataAnnotations;

namespace ProductsDelivery.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ProductType { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int StatusId { get; set; }

        public virtual Status Status { get; set; }
    }
}
