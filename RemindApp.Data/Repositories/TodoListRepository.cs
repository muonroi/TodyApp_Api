namespace RemindApp.Data.Repositories;
public class TodoListRepository(RemindAppDbContext dbContext, MAuthenticateInfoContext authContext)
            : MRepository<TodoListEntity>(dbContext, authContext), ITodoListRepository
{
}

