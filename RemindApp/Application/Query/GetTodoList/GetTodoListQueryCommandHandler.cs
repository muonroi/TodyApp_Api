



namespace RemindApp.Application.Query.GetTodoList;

public class GetTodoListQueryCommandHandler(
    IMapper mapper,
    MAuthenticateInfoContext tokenInfo,
    IAuthenticateRepository authenticateRepository,
    ILogger logger,
    IMediator mediator,
    MPaginationConfig paginationConfig,
    ITodoListQuery todoListQuery
) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<GetTodoListQueryCommand, MResponse<MPagedResult<TodoListResponseModel>>>
{
    public async Task<MResponse<MPagedResult<TodoListResponseModel>>> Handle(GetTodoListQueryCommand request, CancellationToken cancellationToken)
    {
        MResponse<MPagedResult<TodoListResponseModel>> result = new();
        MPagedResult<TodoListResponseModel> todoList = await todoListQuery.GetPagedDataAsync(request.PageIndex, DefaultPageSize, request.Search).ConfigureAwait(false);

        if (todoList == null)
        {
            result.Result = new MPagedResult<TodoListResponseModel>();
            result.AddErrorMessage("Todo list not found.");
            return result;
        }
        result.Result = todoList;
        return result;
    }
}
