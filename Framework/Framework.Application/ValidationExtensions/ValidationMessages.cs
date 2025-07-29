namespace Framework.Application.ValidationExtensions
{
    public static class ValidationMessages
    {
        public const string Required = "وارد کردن این فیلد اجباری است";
        public const string InvalidPhoneNumber = "شماره تلفن نامعتبر است";
        public const string NotFound = "اطلاعات درخواستی یافت نشد";
        public const string MaxLength = "تعداد کاراکترهای وارد شده بیشتر از حد مجاز است";
        public const string MinLength = "تعداد کاراکترهای وارد شده کمتر از حد مجاز است";
        public const string InvalidEmail = "ایمیل وارد شده نامعتبر است";
        public const string InvalidFormat = "فرمت مقدار وارد شده نامعتبر است";
        public const string RangeError = "مقدار وارد شده خارج از محدوده مجاز است";
        public const string MustBeTrue = "این فیلد باید صحیح باشد";
        public const string CompareError = "مقادیر مطابقت ندارند";

        public static string RequiredField(string field) => $"{field} اجباری است";
        public static string MaxLengthField(string field, int maxLength) => $"{field} باید کمتر از {maxLength} کاراکتر باشد";
        public static string MinLengthField(string field, int minLength) => $"{field} باید بیشتر از {minLength} کاراکتر باشد";
        public static string InvalidEmailField(string field) => $"{field} نامعتبر است";
        public static string InvalidFormatField(string field) => "فرمت {field} نامعتبر است";
        public static string RangeErrorField(string field, object min, object max) => $"{field} باید بین {min} تا {max} باشد";
        public static string MustBeTrueField(string field) => $"{field} باید انتخاب شود";
        public static string CompareErrorField(string field1, string field2) => $"{field1} باید با {field2} مطابقت داشته باشد";
    }
}
