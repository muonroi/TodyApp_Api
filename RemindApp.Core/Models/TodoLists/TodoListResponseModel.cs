namespace RemindApp.Core.Models.TodoLists;
public class TodoListResponseModel
{
    public Guid EntityId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public TaskGroup TaskGroup { get; set; } = TaskGroup.Today;
    public DateTime RemindDate { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreateOnTime { get; set; }
}
