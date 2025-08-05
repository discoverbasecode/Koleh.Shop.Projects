using Framework.Domain.Exceptions;

namespace SM.Domain.OrderAgg;

public class OrderItem
{
    #region  OrderItem Properties and Constructor and static Methods

    public Guid OrderId { get; private set; }
    public Guid InventoryId { get; private set; }
    public int Count { get; private set; }
    public decimal Price { get; private set; }
    public decimal TotalPrice => Price * Count;

    public OrderItem() { }
    private OrderItem(Guid inventoryId, int count, decimal price)
    {
        CountGuard(count);
        PriceGuard(price);

        InventoryId = inventoryId;
        Count = count;
        Price = price;
    }

    public void ChangeCount(int newCount)
    {
        CountGuard(newCount);

        Count = newCount;
    }

    public void SetPrice(decimal newPrice)
    {
        PriceGuard(newPrice);
        Price = newPrice;
    }



    #endregion

    #region Guards Methods

    public void PriceGuard(decimal newPrice)
    {
        if (newPrice < 1)
        {
            throw InvalidFieldException.Create("مبلغ", "مبلغ کالا معتبر نیست");
        }
    }

    public void CountGuard(int count)
    {
        if (count < 1)
        {
            throw InvalidFieldException.Create("تعداد", "تعداد کالا معتبر نیست");
        }
    }

    #endregion

}
