namespace RemindApp.Data.Queries;
public class CategoryQuery(RemindAppDbContext dbContext,
    MAuthenticateInfoContext authContext) : MQuery<CategoryEntity>(dbContext, authContext), ICategoryQuery
{
}
