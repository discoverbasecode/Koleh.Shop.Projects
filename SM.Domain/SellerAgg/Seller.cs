using Framework.Domain.Common;
using Framework.Domain.Entities;
using Framework.Domain.Exceptions;
using SM.Domain.SellerAgg.Enums;

namespace SM.Domain.SellerAgg;

public class Seller : AggregateRoot
{
    #region Seller Properties and Constructor and static Methods

    public Guid UserId { get; private set; }
    public string ShopName { get; private set; }
    public string NationalCode { get; private set; }
    public string Description { get; private set; }
    public SellerStatus SellerStatus { get; private set; }
    public List<SellerInventory> Inventories { get; private set; }

    public void ChangeSellerStatus(SellerStatus status)
    {
        SellerStatus = status;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Edit(string shopName, string nationalCode)
    {
        ShopName = shopName;
        NationalCode = nationalCode;
        UpdatedAt = DateTime.UtcNow;
    }

    #endregion


    #region Guards Method

    private void Guard(string shopName, string nationalCode)
    {
        if (shopName == null)
            throw InvalidFieldException.Create("نام فروشگاه", DomainMessageTemplate.Required);
    }

    #endregion
}