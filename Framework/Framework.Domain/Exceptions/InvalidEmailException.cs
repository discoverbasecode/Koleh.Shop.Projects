namespace Framework.Domain.Exceptions;

public class InvalidEmailException(string message) : BaseDomainException(message)
{
    public static InvalidEmailException Create(string email)
    {
        return new InvalidEmailException($"ایمیل '{email}' نامعتبر است. لطفاً یک ایمیل معتبر وارد کنید.");
    }
}