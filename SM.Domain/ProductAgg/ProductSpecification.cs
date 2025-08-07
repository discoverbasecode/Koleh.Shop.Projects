using Framework.Domain.Entities;
using Framework.Domain.Exceptions;

namespace SM.Domain.ProductAgg;

public class ProductSpecification : BaseEntity
{
    public Guid ProductId { get; internal set; }
    public string Key { get; private set; }
    public string Value { get; private set; }

    public ProductSpecification(string key, string value)
    {
        Guards(key, value);
        Key = key;
        Value = value;
    }

    public void Guards(string key, string value)
    {
        if (key == null)
            throw InvalidFieldException.Create("کلید", DomainMessageTemplate.NotEmpty);
        if (value == null)
            throw InvalidFieldException.Create("مقدار", DomainMessageTemplate.NotEmpty);
    }
}