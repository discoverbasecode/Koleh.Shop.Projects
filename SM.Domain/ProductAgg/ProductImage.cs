using Framework.Domain.Entities;
using Framework.Domain.Exceptions;

namespace SM.Domain.ProductAgg;

public class ProductImage : BaseEntity
{
    public Guid ProductId { get; internal set; }
    public string ImageName { get; private set; }
    public int Sequence { get; private set; }

    public ProductImage(string imageName, int sequence)
    {
        Guards(imageName);
        ImageName = imageName;
        Sequence = sequence;
    }

    #region Guards

    private void Guards(string imageName)
    {
        if (imageName == null)
            throw InvalidFieldException.Create("نام تصویر", DomainMessageTemplate.Required);
    }

    #endregion
}