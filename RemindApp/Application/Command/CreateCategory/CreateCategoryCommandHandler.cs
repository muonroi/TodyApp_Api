
namespace RemindApp.Application.Command.CreateCategory;

public class CreateCategoryCommandHandler(
    IMapper mapper,
    MAuthenticateInfoContext tokenInfo,
    IAuthenticateRepository authenticateRepository,
    Serilog.ILogger logger,
    IMediator mediator,
    MPaginationConfig paginationConfig,
    ICategoryQuery categoryQuery,
    ICategoryRepository categoryRepository
) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<CreateCategoryCommand, MResponse<bool>>
{
    public async Task<MResponse<bool>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        MResponse<bool> result = new();
        List<CategoryEntity> isCategoryExist = await categoryQuery.GetByConditionAsync(x => request.Name == x.Name).ConfigureAwait(false);
        if (isCategoryExist != null)
        {
            result.AddErrorMessage("Category already exists.");
            return result;
        }
        CategoryEntity category = new()
        {
            Name = request.Name,
            Icon = request.Icon ?? string.Empty,
            Color = request.Color ?? string.Empty,
        };
        categoryRepository.Add(category);
        await categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        result.Result = true;
        return result;
    }
}
