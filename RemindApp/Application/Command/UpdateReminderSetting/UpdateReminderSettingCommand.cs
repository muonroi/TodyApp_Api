namespace RemindApp.Application.Command.UpdateReminderSetting;

public class UpdateReminderSettingCommand : ReminderSettingRequestModel, IRequest<MResponse<bool>>
{
    public Guid EntityId { get; set; }
}
