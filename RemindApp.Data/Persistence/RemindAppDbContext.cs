








namespace RemindApp.Data.Persistence;

public class RemindAppDbContext : MDbContext
{
    public DbSet<TodoListEntity> TodoListEntities { get; set; }

    public DbSet<ReminderSettingEntity> ReminderSettingEntities { get; set; }

    public RemindAppDbContext(DbContextOptions options)
   : base(options, new NoMediator())
    { }

    public RemindAppDbContext(DbContextOptions options, IMediator mediator) : base(options, mediator)
    { }
}
