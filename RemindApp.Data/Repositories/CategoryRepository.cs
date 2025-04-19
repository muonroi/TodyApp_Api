namespace RemindApp.Data.Repositories;
public class CategoryRepository(RemindAppDbContext dbContext, MAuthenticateInfoContext authContext)
            : MRepository<CategoryEntity>(dbContext, authContext), ICategoryRepository
{
}
