namespace Framework.Domain.Exceptions;

public class InvalidDomainDataException(string message) : BaseDomainException(message)
{
    public static InvalidDomainDataException Create(string fieldName, string reason)
    {
        return new InvalidDomainDataException($"داده نامعتبر در فیلد '{fieldName}': {reason}");
    }
}