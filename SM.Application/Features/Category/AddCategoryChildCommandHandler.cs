using Ardalis.Result;
using Framework.Application.MediatR.Command.Handlers;
using SM.Application.Contracts.Features.Category;
using SM.Domain.CategoryAgg.Repository;
using SM.Domain.CategoryAgg.Service;

namespace SM.Application.Features.Category;

public class AddCategoryChildCommandHandler(
    ICategoryRepository categoryRepository,
    ICategoryDomainService categoryDomainService) :
    IBaseCommandHandler<AddCategoryChildCommand>
{
    public async Task<Result> Handle(AddCategoryChildCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdAsync(request.ParentId, cancellationToken);
        if (category == null)
            return Result.NotFound();

        category.AddChild(request.Title, request.Slug, request.SeoInfo, categoryDomainService);
        await categoryRepository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}