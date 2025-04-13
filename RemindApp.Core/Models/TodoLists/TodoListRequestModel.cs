namespace RemindApp.Core.Models.TodoTasks;
public class TodoListRequestModel
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public TaskGroup TaskGroup { get; set; } = TaskGroup.Today;
    public DateTime RemindDate { get; set; }
    public bool IsCompleted { get; set; }
}
