using Framework.Domain.Common;
using Framework.Domain.Entities;
using Framework.Domain.Exceptions;
using Framework.Domain.Extensions;

namespace SM.Domain.ProductAgg;

public class Product : AggregateRoot
{
    #region Product Properties and Constructor and static Methods

    public string Title { get; private set; }
    public string ImageName { get; private set; }
    public string Descrition { get; private set; }
    public Guid CategoryId { get; private set; }
    public Guid SubCategoryId { get; private set; }
    public string SecondarySubCategoryId { get; private set; }
    public string Slug { get; private set; }
    public ISeoInfo SeoInfo { get; private set; }
    public List<ProductImage> Images { get; private set; }
    public List<ProductSpecification> Specifications { get; private set; }

    public Product()
    {
    }

    public Product(string title, string imageName, string description, Guid categoryId, Guid subCategoryId,
        string secondarySubCategoryId, ISeoInfo seoInfo, string slug)
    {
        Title = title;
        ImageName = imageName;
        Descrition = description;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        SecondarySubCategoryId = secondarySubCategoryId;
        SeoInfo = seoInfo;
        Slug = slug.ToSlug();
    }

    public void Edit(string title, string imageName, string description, Guid categoryId, Guid subCategoryId,
        string secondarySubCategoryId, ISeoInfo seoInfo, string slug)
    {
        Title = title;
        ImageName = imageName;
        Descrition = description;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        SecondarySubCategoryId = secondarySubCategoryId;
        SeoInfo = seoInfo;
        Slug = slug.ToSlug();
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddImageRange(List<ProductImage> images)
    {
        Images.AddRange(images);
    }

    public void AddImage(ProductImage images)
    {
        images.ProductId = Id;
        Images.Add(images);
    }

    public void RemoveImage(Guid imageId)
    {
        var image = Images.FirstOrDefault(c => c.Id == imageId);
        if (image == null)
            return;
        Images.Remove(image);
    }

    public void SetSpecification(List<ProductSpecification> specifications)
    {
        specifications.ForEach(s => s.ProductId = Id);
        Specifications = specifications;
    }

    #endregion


    #region Guards

    public void Guards(string title, string imageName, string description)
    {
        if (title == null) throw InvalidFieldException.Create("عنوان", DomainMessageTemplate.NotEmpty);
        if (imageName == null) throw InvalidFieldException.Create("نام تصویر", DomainMessageTemplate.NotEmpty);
        if (description == null) throw InvalidFieldException.Create("توضیحات", DomainMessageTemplate.NotEmpty);
    }

    #endregion
}