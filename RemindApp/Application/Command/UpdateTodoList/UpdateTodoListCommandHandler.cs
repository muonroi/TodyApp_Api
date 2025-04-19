

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
    public async Task<MResponse<bool>> Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
    {
        MResponse<bool> result = new();
        TodoListEntity? todoTask = await todoTaskQuery.GetByGuidAsync(request.EntityId).ConfigureAwait(false);
        if (todoTask == null)
        {
            result.Result = false;
            result.AddErrorMessage("Todo task not found.");
            return result;
        }
        todoTask.Name = request.Name;
        todoTask.Description = request.Description;
        todoTask.DueDate = request.DueDate;
        todoTask.IsDone = request.IsDone;
        todoTask.HasReminder = request.HasReminder;
        todoTask.ReminderTime = request.ReminderTime;
        todoTask.ReminderRepeats = request.ReminderRepeats;
        todoTask.Priority = Enum.Parse<PriorityLevel>(request.Priority.ToString());
        todoTask.CategoryId = Guid.Parse(request.Category);

        await todoTaskRepository.UpdateAsync(todoTask);
        await todoTaskRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        result.Result = true;
        return await Task.FromResult(result);
    }
}