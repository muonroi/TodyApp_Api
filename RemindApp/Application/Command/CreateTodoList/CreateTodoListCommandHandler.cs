namespace RemindApp.Application.Command.CreateTodoList;

public class CreateTodoListCommandHandler(
    IMapper mapper,
    MAuthenticateInfoContext tokenInfo,
    IAuthenticateRepository authenticateRepository,
    ILogger logger,
    IMediator mediator,
    MPaginationConfig paginationConfig,
    ITodoListRepository todoTaskRepository
) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<CreateTodoListCommand, MResponse<bool>>
{
    public async Task<MResponse<bool>> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
    {
        try
        {
            MResponse<bool> result = new();

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


            TodoListEntity newTodoTask = new()
            {
                Name = request.Name,
                Description = request.Description,
                DueDate = utcDueDate,
                IsDone = request.IsDone,
                HasReminder = request.HasReminder,
                ReminderTime = parsedReminderTime,
                ReminderRepeats = request.ReminderRepeats,
                Priority = entityPriority,
                CategoryId = entityCategoryId,
            };

            todoTaskRepository.Add(newTodoTask);
            await todoTaskRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            result.Result = true;


            return result;
        }
        catch (Exception ex)
        {
            _ = ex;
            throw;
        }

    }
}
