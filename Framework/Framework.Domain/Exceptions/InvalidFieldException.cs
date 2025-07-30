namespace Framework.Domain.Exceptions;

public class InvalidFieldException(string message) : BaseDomainException(message)
{
    public static InvalidFieldException Create(string fieldName, string reason)
    {
        return new InvalidFieldException($"فیلد '{fieldName}' نامعتبر است. دلیل: {reason}");
    }
}