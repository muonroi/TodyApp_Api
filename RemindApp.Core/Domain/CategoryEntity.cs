

namespace RemindApp.Core.Domain;
[Table("Category")]
public class CategoryEntity : MEntity
{
    public string Name { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
}
