namespace RemindApp.Application.Command.UpdateTodoList;

public class UpdateTodoListCommand : TodoListRequestModel, IRequest<MResponse<bool>>
{
    public Guid EntityId { get; set; }
}

