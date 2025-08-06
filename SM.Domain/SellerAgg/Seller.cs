using Framework.Application.ValidationExtensions;
using Framework.Domain.Common;
using Framework.Domain.Entities;
using Framework.Domain.Exceptions;
using SM.Domain.SellerAgg.Enums;

namespace SM.Domain.SellerAgg;

public class Seller : AggregateRoot
{
    #region Seller Properties and Constructor and static Methods

    public Seller(string shopName, string nationalCode, string description)
    {
        Guard(shopName, nationalCode);
        ShopName = shopName;
        NationalCode = nationalCode;
        Description = description;
    }

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
        Guard(shopName, nationalCode);
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

        if (nationalCode == null)
            throw InvalidFieldException.Create("کد ملی", DomainMessageTemplate.Required);

        if (NationalIdValidator.IsValidIranianNationalId(nationalCode) == false)
            throw InvalidFieldException.Create("کد ملی", DomainMessageTemplate.InvalidField);
    }

    #endregion
}