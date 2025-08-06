using Framework.Domain.Common;
using Framework.Domain.Exceptions;

namespace SM.Domain.SellerAgg;

public class SellerInventory : AggregateRoot
{
    #region Seller Inventory Properties and Constructor and static Methods

    public Guid SellerId { get; internal set; }
    public Guid ProductId { get; private set; }
    public string ProductName { get; private set; }
    public uint Count { get; private set; }
    public decimal Price { get; private set; }

    public SellerInventory(Guid productId, string productName, uint count, decimal price)
    {
        PriceGuard(price);
        CountGuard(count);
        ProductId = productId;
        ProductName = productName;
        Count = count;
        Price = price;
    }

    #endregion

    #region Guards Method

    private void PriceGuard(decimal price)
    {
        if (price < 1)
            throw InvalidFieldException.Create("مبلغ", $"نمیتواند کمتر از {price} باشد");
    }

    private void CountGuard(uint count)
    {
        if (count < 1)
            throw InvalidFieldException.Create("تعداد", $"نمیتواند کمتر از {count} باشد");
    }

    #endregion
}