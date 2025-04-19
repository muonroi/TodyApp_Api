

namespace RemindApp.Application.Command.UpdateCategory;

public class UpdateCategoryCommand : CreateCategoryCommand, IRequest<MResponse<bool>>
{
    public Guid EntityId { get; set; }
}
