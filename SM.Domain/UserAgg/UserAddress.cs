using Framework.Domain.Entities;
using Framework.Domain.Exceptions;

namespace SM.Domain.UserAgg;

public class UserAddress : BaseEntity
{
    #region UserAddress Properties and Constructor and static Methods

    public Guid UserId { get; set; }

    public string Province { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string FullAddress { get; private set; }
    public string ReceiverName { get; private set; }
    public string PhoneNumber { get; private set; }
    public bool IsDefault { get; private set; }

    public UserAddress() { }

    private UserAddress(
        string province, string city,
        string postalCode, string fullAddress,
        string receiverName,
        string phoneNumber, bool isDefault)
    {
        GuardsUserAddress(province, city, postalCode, fullAddress, receiverName, phoneNumber, isDefault);
        Province = province;
        City = city;
        PostalCode = postalCode;
        FullAddress = fullAddress;
        ReceiverName = receiverName;
        PhoneNumber = phoneNumber;
        IsDefault = isDefault;
    }

    public void Edit(
        string province, string city,
        string postalCode, string fullAddress,
        string receiverName,
        string phoneNumber, bool isDefault)
    {
        GuardsUserAddress(province, city, postalCode, fullAddress, receiverName, phoneNumber, isDefault);

        Province = province;
        City = city;
        PostalCode = postalCode;
        FullAddress = fullAddress;
        ReceiverName = receiverName;
        PhoneNumber = phoneNumber;
        IsDefault = isDefault;
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = UserId.ToString();
    }


    public static UserAddress Create(
        string province, string city,
        string postalCode, string fullAddress,
        string receiverName,
        string phoneNumber, bool isDefault)
    {
        return new UserAddress(province, city, postalCode, fullAddress, receiverName, phoneNumber, isDefault);
    }

    public void SetDefaultAddress()
    {
        IsDefault = true;
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = UserId.ToString();
    }


    #endregion

    #region Guards Methods

    private void GuardsUserAddress(
        string province, string city,
        string postalCode, string fullAddress,
        string receiverName,
        string phoneNumber, bool isDefault)
    {
        if (string.IsNullOrWhiteSpace(province))
            throw InvalidFieldException.Create("استان", "استان نمی‌تواند خالی باشد.");

        if (string.IsNullOrWhiteSpace(city))
            throw InvalidFieldException.Create("شهر", "شهر نمی‌تواند خالی باشد.");

        if (string.IsNullOrWhiteSpace(postalCode))
            throw InvalidFieldException.Create("کد پستی", "کد پستی نمی‌تواند خالی باشد.");

        if (string.IsNullOrWhiteSpace(fullAddress))
            throw InvalidFieldException.Create("آدرس", "آدرس کامل نمی‌تواند خالی باشد.");

        if (string.IsNullOrWhiteSpace(receiverName))
            throw InvalidFieldException.Create("نام گیرنده", "نام گیرنده نمی‌تواند خالی باشد.");

        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw InvalidFieldException.Create("شماره تلفن", "شماره تلفن نمی‌تواند خالی باشد.");

        if (!phoneNumber.StartsWith("09") || phoneNumber.Length != 11)
            throw InvalidFieldException.Create("شماره تلفن",
                "فرمت شماره تلفن نامعتبر است. باید با 09 شروع شده و 11 رقم باشد.");

    }

    #endregion

}