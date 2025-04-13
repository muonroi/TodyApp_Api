namespace RemindApp.Controllers;

public class ReminderController(
                IMediator mediator,
                IMapper mapper,
                ILogger logger) : MControllerBase(mediator, logger, mapper)
{
    [HttpGet("list", Name = nameof(GetReminderList))]
    public async Task<IActionResult> GetReminderList([FromQuery] GetReminderSettingQueryCommand command, CancellationToken cancellationToken)
    {
        MResponse<ReminderSettingResponseModel> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }

    [HttpPost("create", Name = nameof(CreateReminder))]
    public async Task<IActionResult> CreateReminder([FromBody] CreateReminderSettingCommand command, CancellationToken cancellationToken)
    {
        MResponse<ReminderSettingResponseModel> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }

    [HttpPut("update", Name = nameof(UpdateReminder))]
    public async Task<IActionResult> UpdateReminder([FromBody] UpdateReminderSettingCommand command, CancellationToken cancellationToken)
    {
        MResponse<bool> result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return result.GetActionResult();
    }
}