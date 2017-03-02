namespace PizzaForum.Data.Repositories
{
    using PizzaForum.Models;

    public class TopicsRepository : GenericRepository<Topic>
    {
        public TopicsRepository(PizzaForumDbContext context) 
            : base(context)
        {
        }
    }
}
