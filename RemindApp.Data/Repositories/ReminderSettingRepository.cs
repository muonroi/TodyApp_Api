

namespace RemindApp.Data.Repositories;
public class ReminderSettingRepository(RemindAppDbContext dbContext, MAuthenticateInfoContext authContext)
            : MRepository<ReminderSettingEntity>(dbContext, authContext), IReminderSettingRepository
{
}

