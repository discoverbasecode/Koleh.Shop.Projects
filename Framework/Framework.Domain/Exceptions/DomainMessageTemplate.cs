namespace Framework.Domain.Exceptions;

public abstract class DomainMessageTemplate
{
    public const string Required = "فیلد اجباری است";
    public const string InvalidField = "نامعتبر است";
    public const string NotFound = "اطلاعات درخواستی یافت نشد";
    public const string MaxLength = "تعداد کاراکترهای وارد شده بیشتر از حد مجاز است";
    public const string MinLength = "تعداد کاراکترهای وارد شده کمتر از حد مجاز است";
    public const string InvalidEmail = "نامعتبر است";
    public const string InvalidFormat = "فرمت مقدار وارد شده نامعتبر است";
    public const string RangeError = "مقدار وارد شده خارج از محدوده مجاز است";
    public const string MustBeTrue = "این فیلد باید صحیح باشد";
    public const string CompareError = "مقادیر مطابقت ندارند";
}