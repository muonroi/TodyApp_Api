namespace RemindApp.Core.Models.TodoLists;
public class TodoListRequestModel
{
    public string Name { get; set; } = string.Empty;
    public bool IsDone { get; set; }
    public DateTime? DueDate { get; set; }
    public int Priority { get; set; }
    public bool HasReminder { get; set; }
    public string? Description { get; set; }
    public TimeSpan? ReminderTime { get; set; }
    public bool? ReminderRepeats { get; set; }
    public string Category { get; set; } = string.Empty;
}
