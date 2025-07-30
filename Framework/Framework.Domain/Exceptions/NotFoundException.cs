namespace Framework.Domain.Exceptions;

public class NotFoundException(string message) : Exception(message)
{
    public static NotFoundException Create(string entityName, object key)
        => new NotFoundException($"{entityName} با شناسه '{key}' یافت نشد.");
}