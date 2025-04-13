



namespace RemindApp.Application.Command.CreateTodoList;

public class CreateTodoListCommandHandler(
    IMapper mapper,
    MAuthenticateInfoContext tokenInfo,
    IAuthenticateRepository authenticateRepository,
    Serilog.ILogger logger,
    IMediator mediator,
    MPaginationConfig paginationConfig,
    ITodoListQuery todoTaskQuery,
    ITodoListRepository todoTaskRepository
) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<CreateTodoListCommand, MResponse<TodoListResponseModel>>
{
    public Task<MResponse<TodoListResponseModel>> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
