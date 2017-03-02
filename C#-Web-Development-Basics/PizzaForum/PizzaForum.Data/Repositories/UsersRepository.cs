namespace PizzaForum.Data.Repositories
{
    using PizzaForum.Models;

    public class UsersRepository : GenericRepository<User>
    {
        public UsersRepository(PizzaForumDbContext context) 
            : base(context)
        {
        }
    }
}
