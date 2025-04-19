



namespace RemindApp.Data.Queries;
public class TodoListQuery(RemindAppDbContext dbContext,
    MAuthenticateInfoContext authContext) : MQuery<TodoListEntity>(dbContext, authContext), ITodoListQuery
{
    public async Task<MPagedResult<TodoListResponseModel>> GetPagedDataAsync(int pageIndex, int pageSize, string? search)
    {
        IQueryable<TodoListEntity> query = Queryable;
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(x => x.Name.Contains(search));
        }
        int totalCount = await query.CountAsync();

        List<TodoListEntity> pagedCustomers = [.. query
          .Skip((pageIndex - 1) * pageSize)
          .Take(pageSize)];

        MPagedResult<TodoListResponseModel> result = new()
        {
            CurrentPage = pageIndex,
            PageSize = pageSize,
            RowCount = totalCount,
            Items = pagedCustomers.Select(x => new TodoListResponseModel
            {
                EntityId = x.EntityId,
                Name = x.Name,
                IsDone = x.IsDone,
                DueDate = x.DueDate,
                Priority = x.Priority,
                HasReminder = x.HasReminder,
                ReminderRepeats = x.ReminderRepeats,
                Description = x.Description,
                ReminderTime = x.ReminderTime,
                Category = x.CategoryId ?? Guid.Empty
            })
        };

        return result;
    }
}
