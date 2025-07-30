using Framework.Domain.Entities;
using Framework.Domain.Exceptions;
using SM.Domain.UserAgg.Enums;

namespace SM.Domain.UserAgg;

public class Wallet : BaseEntity
{
    #region  Wallet Properties and Constructor and static Methods

    public Guid UserId { get; private set; }
    public decimal Price { get; private set; }
    public string Description { get; private set; }
    public bool IsFinally { get; private set; }
    public DateTime FinallyDate { get; private set; }
    public WalletType WalletType { get; private set; }

    public Wallet() { }
    private Wallet(Guid userId, decimal price, string description, WalletType walletType)
    {
        if (price <= 500)
        {
            throw InvalidFieldException.Create("قیمت", "قیمت باید بیشتر از ۵۰۰ تومان باشد.");
        }
        UserId = userId;
        Price = price;
        Description = description;
        WalletType = walletType;
        IsFinally = false;
        FinallyDate = DateTime.MinValue;
    }

    public void Finally(string refCode)
    {
        IsFinally = true;
        FinallyDate = DateTime.UtcNow;
        Description = $"کد پیگیری {refCode}";
    }

    public void Finally()
    {
        IsFinally = true;
        FinallyDate = DateTime.UtcNow;
    }

    #endregion

}
