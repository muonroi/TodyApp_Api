


namespace RemindApp.Core.Domain;

[Table("ReminderSetting")]
public class ReminderSettingEntity : MEntity
{
    public ReminderSystem ReminderSystem { get; set; } = ReminderSystem.Mobile;

    public int ReminderAgainTimeOfMinute { get; set; }
}
