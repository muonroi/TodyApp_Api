using RemindApp.Core.Models.TodoLists;

namespace RemindApp.Application.Query.GetTodoList;

public class GetTodoListQueryCommand : IRequest<MResponse<TodoListResponseModel>>
{
}
