namespace RemindApp.Core.Models.ReminderSettings;
public class ReminderSettingResponseModel
{
    public Guid EntityId { get; set; }

    public ReminderSystem ReminderSystem { get; set; } = ReminderSystem.Mobile;

    public int ReminderAgainTimeOfMinute { get; set; }

    public DateTime CreateOnTime { get; set; }

}
