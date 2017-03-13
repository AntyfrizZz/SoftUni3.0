using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Models;

namespace IssueTracker.Data.Repositories
{
    public class LoginRepository : GenericRepository<Login>
    {
        public LoginRepository(IssueTrackerDbContext context) 
            : base(context)
        {
        }
    }
}
