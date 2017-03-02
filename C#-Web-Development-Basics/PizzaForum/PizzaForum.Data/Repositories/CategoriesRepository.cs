namespace PizzaForum.Data.Repositories
{
    using PizzaForum.Models;

    public class CategoriesRepository : GenericRepository<Category>
    {
        public CategoriesRepository(PizzaForumDbContext context) 
            : base(context)
        {
        }
    }
}
