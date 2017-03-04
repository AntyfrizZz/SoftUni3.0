using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaForum.App.BindingModels;
using PizzaForum.App.ViewModels;
using PizzaForum.Models;

namespace PizzaForum.App.Services
{
    public class CategoriesService : Service
    {
        internal AllViewModel GetAllViewModel(User user)
        {
            var view = new AllViewModel();

            view.Categories = this.uow.CategoriesRepository
                .Get()
                .Select(c => new AllCategoriesViewModel()
                {
                    Id = c.Id,
                    CategoryName = c.Name
                });

            return view;
        }

        internal bool IsNewCategoryValid(NewCategoryBindingModel model)
        {
            return !string.IsNullOrEmpty(model.Name);
        }

        internal void AddNewCategory(NewCategoryBindingModel model)
        {
            this.uow.CategoriesRepository.Insert(new Category()
            {
                Name = model.Name
            });

            this.uow.Save();
        }
    }
}
