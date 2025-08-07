using Ardalis.SharedKernel;
using Framework.Domain.Common;
using Framework.Domain.Entities;
using Framework.Domain.Exceptions;
using Framework.Domain.Extensions;
using SM.Domain.CategoryAgg.Service;

namespace SM.Domain.CategoryAgg;

public class Category : AggregateRoot, IAggregateRoot
{
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public ISeoInfo SeoInfo { get; private set; }
    public List<Category> Childes { get; private set; }
    public Guid? ParentId { get; private set; }

    public Category(string title, string slug, ISeoInfo seoInfo, ICategoryDomainService categoryDomainService)
    {
        Guard(title, slug, categoryDomainService);
        Title = title;
        Slug = slug;
        SeoInfo = seoInfo;
    }

    public void Edit(string title, string slug, ISeoInfo seoInfo, ICategoryDomainService categoryDomainService)
    {
        Guard(title, slug, categoryDomainService);
        Title = title;
        Slug = slug;
        SeoInfo = seoInfo;
    }

    public void AddChild(string title, string slug, ISeoInfo seoInfo, ICategoryDomainService categoryDomainService)
    {
        Childes.Add(new Category(title, slug, seoInfo, categoryDomainService)
        {
            ParentId = Id
        });
    }

    private static void Guard(string? title, string? slug, ICategoryDomainService categoryDomainService)
    {
        if (title == null)
            InvalidFieldException.Create("عنوان", DomainMessageTemplate.NotEmpty);

        if (slug != null)
            if (categoryDomainService.SlugExists(slug.ToSlug()))
                SlugIsDuplicateException.Create(slug);
    }
}