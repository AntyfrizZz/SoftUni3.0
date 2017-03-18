namespace CarDealer.Models.ViewModels.Sales
{
    using CarDealer.Models.ViewModels.Cars;
    using Customers;

    public class SaleVm
    {
        public CarVm Car { get; set; }

        public AllCustomerVm Customer { get; set; }

        public double Price { get; set; }

        public double Discount { get; set; }
    }
}
