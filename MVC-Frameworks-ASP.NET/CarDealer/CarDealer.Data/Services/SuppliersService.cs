namespace CarDealer.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Models.BindingModels.Suppliers;
    using Models.EntityModels;
    using Models.ViewModels.Suppliers;

    public class SuppliersService : Service
    {
        public IEnumerable<SupplierVm> GetAllSuppliersByType(string type)
        {
            IEnumerable<Supplier> suppliersWanted;

            if (type.ToLower() == "local")
            {
                suppliersWanted = this.Context.Suppliers
                    .Where(supplier => !supplier.IsImporter);
            }
            else if (type.ToLower() == "importers")
            {
                suppliersWanted = this.Context.Suppliers
                    .Where(supplier => supplier.IsImporter);
            }
            else
            {
                throw new ArgumentException("Invalid argument for the type of the supplier!");
            }

            IEnumerable<SupplierVm> viewModels =
                Mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierVm>>(suppliersWanted);

            return viewModels;
        }

        public void AddSupplier(AddSupplierBm bind, int userId)
        {
            Supplier supplier = Mapper.Map<AddSupplierBm, Supplier>(bind);
            this.Context.Suppliers.Add(supplier);
            this.Context.SaveChanges();

            this.AddLog(userId, OperationLog.Add, "suppliers");
        }

        public EditSupplierVm GetEditSupplierVm(int id)
        {
            Supplier supplier = this.Context.Suppliers.Find(id);
            EditSupplierVm vm = Mapper.Map<Supplier, EditSupplierVm>(supplier);
            return vm;
        }

        public void EditSupplier(EditSupplierBm bind, int userId)
        {
            Supplier model = this.Context.Suppliers.Find(bind.Id);
            model.IsImporter = bind.IsImporter == "on";
            model.Name = bind.Name;
            this.Context.SaveChanges();

            this.AddLog(userId, OperationLog.Edit, "suppliers");
        }

        public DeleteSuplierVm GetDeleteSupplierVm(int id)
        {
            Supplier supplier = this.Context.Suppliers.Find(id);

            if (supplier == null)
            {
                throw new ArgumentException($"Supplier with Id {id} does not exist!");
            }

            DeleteSuplierVm vm = Mapper.Map<Supplier, DeleteSuplierVm>(supplier);
            return vm;
        }

        public void DeleteSupplier(DeleteSupplierBm bind, int userId)
        {
            Supplier supplier = this.Context.Suppliers.Find(bind.Id);
            this.Context.Suppliers.Remove(supplier);
            this.Context.SaveChanges();

            this.AddLog(userId, OperationLog.Delete, "suppliers");
        }
    }
}
