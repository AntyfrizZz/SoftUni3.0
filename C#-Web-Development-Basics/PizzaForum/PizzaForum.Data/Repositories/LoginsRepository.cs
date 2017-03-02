namespace PizzaForum.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PizzaForum.Models;

    public class LoginsRepository : GenericRepository<Login>
    {
        public LoginsRepository(PizzaForumDbContext context) 
            : base(context)
        {
        }
    }
}
