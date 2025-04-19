namespace RemindApp.Application.Command.CreateCategory;

public class CreateCategoryCommand : IRequest<MResponse<bool>>
{
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; } = string.Empty;
    public string? Color { get; set; } = string.Empty;
}
