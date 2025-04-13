

namespace RemindApp.Application.Command.UpdateTodoList;

public class UpdateTodoListCommandHandler(
    IMapper mapper,
    MAuthenticateInfoContext tokenInfo,
    IAuthenticateRepository authenticateRepository,
    Serilog.ILogger logger,
    IMediator mediator,
    MPaginationConfig paginationConfig,
    ITodoListQuery todoTaskQuery,
    ITodoListRepository todoTaskRepository
) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<UpdateTodoListCommand, MResponse<bool>>
{
    public Task<MResponse<bool>> Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}