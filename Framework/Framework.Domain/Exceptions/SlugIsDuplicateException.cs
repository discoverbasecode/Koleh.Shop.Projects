namespace Framework.Domain.Exceptions;

public class SlugIsDuplicateException(string message) : BaseDomainException(message)
{
    public static SlugIsDuplicateException Create(string slug)
    {
        return new SlugIsDuplicateException($"مقدار Slug تکراری است: '{slug}'. لطفاً مقدار یکتایی وارد کنید.");
    }
}