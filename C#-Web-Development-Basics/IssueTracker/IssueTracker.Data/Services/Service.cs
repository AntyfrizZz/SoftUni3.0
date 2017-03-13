using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Data.Services
{
    public abstract class Service
    {
        protected UnitOfWork unitOfWork;

        public Service()
        {
            this.unitOfWork = new UnitOfWork();
        }
    }
}
