













namespace RemindApp.Controllers;
public class TodoListController(
                IMediator mediator,
                IMapper mapper,
                ILogger logger) : MControllerBase(mediator, logger, mapper)
{
    [HttpGet("list", Name = nameof(GetTodoTaskList))]
    [AllowAnonymous]
    public async Task<IActionResult> GetTodoTaskList([FromQuery] GetTodoListQueryCommand command, CancellationToken cancellationToken)
    {
        MResponse<MPagedResult<TodoListResponseModel>> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }

    [HttpPost("create", Name = nameof(CreateTodoTask))]
    public async Task<IActionResult> CreateTodoTask([FromBody] CreateTodoListCommand command, CancellationToken cancellationToken)
    {
        MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }

    [HttpPut("update", Name = nameof(UpdateTodoTask))]
    public async Task<IActionResult> UpdateTodoTask([FromBody] UpdateTodoListCommand command, CancellationToken cancellationToken)
    {
        MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }

    [HttpPost("category-create", Name = nameof(CreateCategory))]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }

    [HttpPut("category-update", Name = nameof(UpdateCategory))]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }
}
