namespace CarDealer.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Models.BindingModels.Parts;
    using Models.EntityModels;
    using Models.ViewModels.Parts;

    public class PartsService : Service
    {
        public object GetAddVm()
        {
            return this.Context.Suppliers.Select(supplier => new AddPartSupplierVm()
            {
                Id = supplier.Id,
                Name = supplier.Name
            });
        }

        public void AddPart(AddPartBm bind)
        {
            Part part = Mapper.Map<AddPartBm, Part>(bind);
            Supplier wantedSupplier = this.Context.Suppliers.Find(bind.SupplierId);
            part.Supplier = wantedSupplier;

            if (part.Quantity == 0)
            {
                part.Quantity = 1;
            }

            this.Context.Parts.Add(part);
            this.Context.SaveChanges();
        }

        public IEnumerable<AllPartVm> GetAllPartVms()
        {
            IEnumerable<Part> parts = this.Context.Parts;
            IEnumerable<AllPartVm> vms = Mapper.Map<IEnumerable<Part>, IEnumerable<AllPartVm>>(parts);
            return vms;
        }

        public DeletePartVm GetDeleteVm(int id)
        {
            Part model = this.Context.Parts.Find(id);
            DeletePartVm vm = Mapper.Map<Part, DeletePartVm>(model);
            return vm;
        }

        public void DeletePart(DeletePartBm bind)
        {
            Part part = this.Context.Parts.Find(bind.PartId);
            this.Context.Parts.Remove(part);
            this.Context.SaveChanges();
        }

        public EditPartVm GetEditVm(int id)
        {
            Part part = this.Context.Parts.Find(id);
            EditPartVm vm = Mapper.Map<Part, EditPartVm>(part);
            return vm;
        }

        public void EditPart(EditPartBm bind)
        {
            Part model = this.Context.Parts.Find(bind.Id);

            if (model == null)
            {
                throw new ArgumentException($"Cannot find part with id {bind.Id}!");
            }

            model.Quantity = bind.Quantity;
            model.Price = bind.Price;

            this.Context.SaveChanges();
        }
    }
}
