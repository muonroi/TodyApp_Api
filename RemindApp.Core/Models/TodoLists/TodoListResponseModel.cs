namespace RemindApp.Core.Models.TodoLists;
public class TodoListResponseModel
{
    public Guid EntityId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsDone { get; set; }
    public DateTime? DueDate { get; set; }
    public PriorityLevel? Priority { get; set; }
    public bool HasReminder { get; set; }
    public string? Description { get; set; }
    public TimeSpan? ReminderTime { get; set; }
    public bool? ReminderRepeats { get; set; }
    public Guid Category { get; set; }

}
