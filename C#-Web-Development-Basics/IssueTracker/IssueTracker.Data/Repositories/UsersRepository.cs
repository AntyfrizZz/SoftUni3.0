using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Models;

namespace IssueTracker.Data.Repositories
{
    public class UsersRepository : GenericRepository<User>
    {
        public UsersRepository(IssueTrackerDbContext context) 
            : base(context)
        {
        }
    }
}
