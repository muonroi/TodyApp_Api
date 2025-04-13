




namespace RemindApp.Data.Queries;
public class ReminderSettingQuery(RemindAppDbContext dbContext,
    MAuthenticateInfoContext authContext) : MQuery<ReminderSettingEntity>(dbContext, authContext), IReminderSettingQuery
{
}
