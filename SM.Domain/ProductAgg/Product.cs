using Framework.Domain.Common;
using Framework.Domain.Entities;

namespace SM.Domain.ProductAgg;

public class Product : AggregateRoot
{
    public string Title { get; private set; }
    public string ImageName { get; private set; }
    public string Descrition { get; private set; }
    public Guid CategoryId { get; private set; }
    public Guid SubCategoryId { get; private set; }
    public string SecondarySubCategoryId { get; private set; }
    public ISeoInfo SeoInfo { get; private set; }
    public List<ProductImage> Images { get; private set; }
    public List<ProductSpecification> Specifications { get; private set; }
    
}

public class ProductImage : BaseEntity
{
}

public class ProductSpecification : BaseEntity
{
}