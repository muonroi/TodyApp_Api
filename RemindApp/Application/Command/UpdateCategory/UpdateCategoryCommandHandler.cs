

namespace RemindApp.Application.Command.UpdateCategory;

public class UpdateCategoryCommandHandler(
    IMapper mapper,
    MAuthenticateInfoContext tokenInfo,
    IAuthenticateRepository authenticateRepository,
    Serilog.ILogger logger,
    IMediator mediator,
    MPaginationConfig paginationConfig,
    ICategoryQuery categoryQuery,
    ICategoryRepository categoryRepository
) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<UpdateCategoryCommand, MResponse<bool>>
{
    public async Task<MResponse<bool>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        MResponse<bool> result = new();
        CategoryEntity? isCategoryExist = await categoryQuery.GetByGuidAsync(request.EntityId).ConfigureAwait(false);
        if (isCategoryExist is null)
        {
            result.AddErrorMessage("Category already not exists.");
            return result;
        }
        isCategoryExist.Name = request.Name;
        isCategoryExist.Icon = request.Icon ?? string.Empty;
        isCategoryExist.Color = request.Color ?? string.Empty;
        await categoryRepository.UpdateAsync(isCategoryExist);
        await categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        result.Result = true;
        return result;
    }
}