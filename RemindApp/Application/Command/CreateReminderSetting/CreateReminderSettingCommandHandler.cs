



namespace RemindApp.Application.Command.CreateReminderSetting;

public class CreateReminderSettingCommandHandler(
    IMapper mapper,
    MAuthenticateInfoContext tokenInfo,
    IAuthenticateRepository authenticateRepository,
    Serilog.ILogger logger,
    IMediator mediator,
    MPaginationConfig paginationConfig,
    IReminderSettingQuery reminderSettingQuery,
    IReminderSettingRepository reminderSettingRepository
) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<CreateReminderSettingCommand, MResponse<ReminderSettingResponseModel>>
{
    public Task<MResponse<ReminderSettingResponseModel>> Handle(CreateReminderSettingCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
