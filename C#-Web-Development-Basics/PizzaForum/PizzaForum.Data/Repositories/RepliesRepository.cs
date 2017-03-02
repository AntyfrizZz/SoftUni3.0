namespace PizzaForum.Data.Repositories
{
    using PizzaForum.Models;

    public class RepliesRepository : GenericRepository<Reply>
    {
        public RepliesRepository(PizzaForumDbContext context) 
            : base(context)
        {
        }
    }
}
