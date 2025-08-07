using Ardalis.Result;
using Framework.Application.MediatR.Command.Handlers;
using SM.Application.Contracts.Features.Category;
using SM.Domain.CategoryAgg.Repository;
using SM.Domain.CategoryAgg.Service;

namespace SM.Application.Features.Category;

public class CreateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    ICategoryDomainService categoryDomainService) : IBaseCommandHandler<CreateCategoryCommand>
{
    public async Task<Result> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Domain.CategoryAgg.Category(
            request.Title, request.Slug, request.SeoInfo, categoryDomainService);
        await categoryRepository.AddAsync(category, cancellationToken);
        await categoryRepository.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}