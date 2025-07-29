namespace Framework.Domain.Exceptions;

public class InvalidPhoneNumberException(string message) : BaseDomainException(message)
{
    public static InvalidPhoneNumberException Create(string phoneNumber)
    {
        return new InvalidPhoneNumberException($"شماره تلفن '{phoneNumber}' نامعتبر است. لطفاً یک شماره تلفن معتبر وارد کنید.");
    }
}