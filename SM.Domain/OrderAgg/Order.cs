using Framework.Domain.Common;
using Framework.Domain.Exceptions;
using SM.Domain.OrderAgg.Enums;
using SM.Domain.OrderAgg.ValueObjects;

namespace SM.Domain.OrderAgg;

public class Order : AggregateRoot
{
    public Order() { }
    private Order(Guid userId)
    {
        UserId = userId;
        Status = OrderStatus.Pending;
        OrderItems = new List<OrderItem>();
    }

    public Guid UserId { get; private set; }
    public OrderDiscount? Discount { get; private set; }
    public OrderAddress? Address { get; private set; }
    public ShippingMethod? ShippingMethod { get; private set; }
    public OrderStatus Status { get; private set; }
    public List<OrderItem> OrderItems { get; private set; }

    public decimal TotalPrice
    {
        get
        {
            var totalPrice = OrderItems.Sum(c => c.TotalPrice);

            if (ShippingMethod != null)
                totalPrice += ShippingMethod.ShippingCost;

            if (Discount != null)
                totalPrice -= Discount.DiscountAmount;

            return totalPrice;
        }

    }

    public int ItemCount => OrderItems.Count;


    public void AddItem(OrderItem orderItem)
    {
        OrderItems.Add(orderItem);
    }
    public void RemoveItem(Guid orderItemId)
    {
        var currentItem = OrderItems.FirstOrDefault(c => c.OrderId == orderItemId);
        if (currentItem != null)
            OrderItems.Remove(currentItem!);
    }

    public void ChangeCount(Guid orderItemId, int newCount)
    {
        var currentItem = OrderItems.FirstOrDefault(c => c.OrderId == orderItemId);
        if (currentItem == null)
            throw InvalidFieldException.Create("سفارش", $"آیتم سفارشی با شناسه {orderItemId} یافت نشد.");
        currentItem.ChangeCount(newCount);
    }

    public void ChangeStatus(OrderStatus orderStatus)
    {
        Status = orderStatus;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Checkout(OrderAddress orderAddress)
    {
        Address = orderAddress;
    }
}