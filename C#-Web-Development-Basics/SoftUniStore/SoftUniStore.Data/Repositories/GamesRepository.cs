using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftUniStore.Models;

namespace SoftUniStore.Data.Repositories
{
    public class GamesRepository : GenericRepository<Game>
    {
        public GamesRepository(SoftUniStoreDbContext context) 
            : base(context)
        {
        }
    }
}
