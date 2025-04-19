



namespace RemindApp.Application.Query.GetTodoList;

public class GetTodoListQueryCommand : IRequest<MResponse<MPagedResult<TodoListResponseModel>>>
{
    public string? Search { get; set; } = string.Empty;
    public int PageIndex { get; set; } = 1;
}
