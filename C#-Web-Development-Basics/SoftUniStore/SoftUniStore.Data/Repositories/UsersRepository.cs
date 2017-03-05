using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftUniStore.Models;

namespace SoftUniStore.Data.Repositories
{
    public class UsersRepository : GenericRepository<User>
    {
        public UsersRepository(SoftUniStoreDbContext context) 
            : base(context)
        {
        }
    }
}
