namespace RemindApp.Application.Command.UpdateReminderSetting;

public class UpdateReminderSettingCommandHandler(
    IMapper mapper,
    MAuthenticateInfoContext tokenInfo,
    IAuthenticateRepository authenticateRepository,
    Serilog.ILogger logger,
    IMediator mediator,
    MPaginationConfig paginationConfig,
    IReminderSettingQuery reminderSettingQuery,
    IReminderSettingRepository reminderSettingRepository
) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<UpdateReminderSettingCommand, MResponse<bool>>
{
    public Task<MResponse<bool>> Handle(UpdateReminderSettingCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

