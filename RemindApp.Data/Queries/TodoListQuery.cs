namespace RemindApp.Data.Queries;
public class TodoListQuery(RemindAppDbContext dbContext,
    MAuthenticateInfoContext authContext) : MQuery<TodoListEntity>(dbContext, authContext), ITodoListQuery
{
}
