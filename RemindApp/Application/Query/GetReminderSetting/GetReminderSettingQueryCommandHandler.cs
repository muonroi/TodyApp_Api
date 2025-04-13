

namespace RemindApp.Application.Query.GetReminderSetting;

public class GetReminderSettingQueryCommandHandler(
    IMapper mapper,
    MAuthenticateInfoContext tokenInfo,
    IAuthenticateRepository authenticateRepository,
    Serilog.ILogger logger,
    IMediator mediator,
    MPaginationConfig paginationConfig,
    IReminderSettingQuery reminderSettingQuery
) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<GetReminderSettingQueryCommand, MResponse<ReminderSettingResponseModel>>
{
    public Task<MResponse<ReminderSettingResponseModel>> Handle(GetReminderSettingQueryCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
