


namespace RemindApp.Core.Interfaces.Queries;
public interface ITodoListQuery
    : IMQueries<TodoListEntity>
{
    Task<MPagedResult<TodoListResponseModel>> GetPagedDataAsync(int pageIndex, int pageSize, string? search);
}
