using Framework.Application.ValidationExtensions;
using Framework.Domain.Common;
using Framework.Domain.Entities;
using Framework.Domain.Exceptions;
using SM.Domain.SellerAgg.Enums;

namespace SM.Domain.SellerAgg;

public class Seller : AggregateRoot
{
    #region Seller Properties and Constructor and static Methods

    private Seller()
    {
    }

    public Seller(string shopName, string nationalCode, string description)
    {
        Guard(shopName, nationalCode);
        ShopName = shopName;
        NationalCode = nationalCode;
        Description = description;
        Inventories = new List<SellerInventory>();
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

    public void AddInventory(SellerInventory inventory)
    {
        if (Inventories.Any(c => c.ProductId == inventory.ProductId))
            throw InvalidFieldException.Create("شناسه محصول", "محصول با این شناسه قبلاً در موجودی ثبت شده است.");
        Inventories.Add(inventory);
    }

    public void EditInventory(SellerInventory inventory)
    {
        var currentInventory = Inventories.FirstOrDefault(c => c.Id == inventory.Id);
        if (currentInventory == null)
            throw InvalidFieldException.Create("شناسه", DomainMessageTemplate.NotFound);

        Inventories.Remove(currentInventory);
        Inventories.Add(inventory);
    }

    public void DeleteInventory(Guid id)
    {
        var currentInventory = Inventories.FirstOrDefault(c => c.Id == id);
        if (currentInventory == null)
            throw InvalidFieldException.Create("شناسه", DomainMessageTemplate.NotFound);
        Inventories.Remove(currentInventory);
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