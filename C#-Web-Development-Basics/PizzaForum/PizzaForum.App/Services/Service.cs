using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaForum.Data;

namespace PizzaForum.App.Services
{
    public abstract class Service
    {
        protected UnitOfWork uow;

        public Service()
        {
            this.uow = new UnitOfWork();
        }
    }
}
