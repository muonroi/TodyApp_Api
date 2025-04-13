



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
    IRequestHandler<GetTodoListQueryCommand, MResponse<TodoListResponseModel>>
{
    public Task<MResponse<TodoListResponseModel>> Handle(GetTodoListQueryCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
