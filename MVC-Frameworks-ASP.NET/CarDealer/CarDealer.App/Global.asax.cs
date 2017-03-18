namespace CarDealer.App
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using AutoMapper;
    using Models.BindingModels.Cars;
    using Models.BindingModels.Customers;
    using Models.BindingModels.Parts;
    using Models.BindingModels.Suppliers;
    using Models.BindingModels.Users;
    using Models.EntityModels;
    using Models.ViewModels.Cars;
    using Models.ViewModels.Customers;
    using Models.ViewModels.Parts;
    using Models.ViewModels.Sales;
    using Models.ViewModels.Suppliers;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMaps()
        {
            Mapper.Initialize(expression =>
            {
                // Customer
                expression.CreateMap<Customer, AllCustomerVm>();
                expression.CreateMap<Customer, EditCustomerVm>();
                expression.CreateMap<Customer, AddSaleCustomerVm>();
                expression.CreateMap<Customer, AboutCustomerVm>()
                   .ForMember(vm => vm.BoughtCarsCount, ce => ce.MapFrom(m => m.Sales.Count))
                   .ForMember(vm => vm.TotalSpentMoney, ce => ce.MapFrom(m => m.Sales.Sum(sale => sale.Car.Parts.Sum(part => part.Price))));
                expression.CreateMap<AddCustomerBm, Customer>();

                // Car
                expression.CreateMap<Car, CarVm>();
                expression.CreateMap<Car, AddSaleCarVm>();
                expression.CreateMap<AddCarBm, Car>()
                    .ForMember(car => car.Parts, configurationExpression => configurationExpression.Ignore());

                // Supplier
                expression.CreateMap<Supplier, SupplierVm>()
                    .ForMember(vm => vm.NumberOfPartsToSupply, ce => ce.MapFrom(m => m.Parts.Count));
                expression.CreateMap<AddSupplierBm, Supplier>();
                expression.CreateMap<Supplier, EditSupplierVm>();
                expression.CreateMap<Supplier, DeleteSuplierVm>();

                // Part
                expression.CreateMap<Part, PartVm>();
                expression.CreateMap<Part, AllPartVm>();
                expression.CreateMap<Part, DeletePartVm>();
                expression.CreateMap<Part, EditPartVm>();
                expression.CreateMap<AddPartBm, Part>();

                // Sale
                expression.CreateMap<Sale, SaleVm>()
                    .ForMember(vm => vm.Price, ce => ce.MapFrom(m => m.Car.Parts.Sum(part => part.Price)));
               
                // User
                expression.CreateMap<RegisterUserBm, User>();
            });
        }
    }
}
