











namespace RemindApp.Controllers;
public class TodoListController(
                IMediator mediator,
                IMapper mapper,
                ILogger logger) : MControllerBase(mediator, logger, mapper)
{
    [HttpGet("list", Name = nameof(GetTodoTaskList))]
    public async Task<IActionResult> GetTodoTaskList([FromQuery] GetTodoListQueryCommand command, CancellationToken cancellationToken)
    {
        MResponse<TodoListResponseModel> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }

    [HttpPost("create", Name = nameof(CreateTodoTask))]
    public async Task<IActionResult> CreateTodoTask([FromBody] CreateTodoListCommand command, CancellationToken cancellationToken)
    {
        MResponse<TodoListResponseModel> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }

    [HttpPut("update", Name = nameof(UpdateTodoTask))]
    public async Task<IActionResult> UpdateTodoTask([FromBody] UpdateTodoListCommand command, CancellationToken cancellationToken)
    {
        MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }
}
