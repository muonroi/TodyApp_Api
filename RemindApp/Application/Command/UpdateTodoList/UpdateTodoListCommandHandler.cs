

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
        DateTime? utcDueDate = null;
        if (request.DueDate.HasValue)
        {
            DateTime dateValue = request.DueDate.Value;
            if (dateValue.Kind == DateTimeKind.Local)
            {
                utcDueDate = dateValue.ToUniversalTime();
            }
            else if (dateValue.Kind == DateTimeKind.Unspecified)
            {
                utcDueDate = TimeZoneInfo.ConvertTimeToUtc(dateValue, TimeZoneInfo.Local);
            }
            else
            {
                utcDueDate = dateValue;
            }
        }

        TimeSpan? parsedReminderTime = request.ReminderTime;

        PriorityLevel? entityPriority = null;
        if (request.Priority >= 0 && request.Priority < PriorityLevel.GetValues(typeof(PriorityLevel)).Length)
        {
            entityPriority = (PriorityLevel)request.Priority;
        }
        Guid? entityCategoryId = null;
        if (Guid.TryParse(request.Category, out Guid parsedGuid))
        {
            entityCategoryId = parsedGuid;
        }
        todoTask.Name = request.Name;
        todoTask.Description = request.Description;
        todoTask.DueDate = utcDueDate;
        todoTask.IsDone = request.IsDone;
        todoTask.HasReminder = request.HasReminder;
        todoTask.ReminderTime = parsedReminderTime;
        todoTask.ReminderRepeats = request.ReminderRepeats;
        todoTask.Priority = entityPriority;
        todoTask.CategoryId = entityCategoryId;

        await todoTaskRepository.UpdateAsync(todoTask);
        await todoTaskRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        result.Result = true;
        return await Task.FromResult(result);
    }
}