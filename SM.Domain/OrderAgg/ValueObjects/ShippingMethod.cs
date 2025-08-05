using Framework.Domain.Common;

namespace SM.Domain.OrderAgg.ValueObjects;

public class ShippingMethod : ValueObject
{
    public string ShippingType { get; private set; }
    public decimal ShippingCost { get; private set; }

    public ShippingMethod(string shippingType, decimal shippingCost)
    {
        ShippingType = shippingType;
        ShippingCost = shippingCost;
    }
}