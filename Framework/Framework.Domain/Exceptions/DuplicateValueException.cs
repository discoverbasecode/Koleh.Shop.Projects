namespace Framework.Domain.Exceptions;

public class DuplicateValueException(string message) : BaseDomainException(message)
{
    public static DuplicateValueException Create(string fieldName, string value)
    {
        return new DuplicateValueException(
            $"مقدار '{value}' برای فیلد '{fieldName}' قبلاً ثبت شده است. لطفاً مقدار دیگری وارد کنید.");
    }
}