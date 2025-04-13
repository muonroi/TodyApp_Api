namespace RemindApp.Core.Models.ReminderSettings;
public class ReminderSettingRequestModel
{
    public ReminderSystem ReminderSystem { get; set; } = ReminderSystem.Mobile;

    public int ReminderAgainTimeOfMinute { get; set; }
}
