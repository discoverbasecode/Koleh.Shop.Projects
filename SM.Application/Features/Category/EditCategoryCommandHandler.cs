using Ardalis.Result;
using Framework.Application.MediatR.Command.Handlers;
using SM.Application.Contracts.Features.Category;
using SM.Domain.CategoryAgg.Repository;
using SM.Domain.CategoryAgg.Service;

namespace SM.Application.Features.Category;

public class EditCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    ICategoryDomainService categoryDomainService) : IBaseCommandHandler<EditCategoryCommand>
{
    public async Task<Result> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);
        if (category == null)
            return Result.NotFound();

        category.Edit(request.Title, request.Slug, request.SeoInfo, categoryDomainService);

        categoryRepository.Update(category);
        await categoryRepository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}