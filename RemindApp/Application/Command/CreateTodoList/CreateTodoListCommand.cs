namespace RemindApp.Application.Command.CreateTodoList;

public class CreateTodoListCommand : TodoListRequestModel
    , IRequest<MResponse<bool
        >>
{
}
