using Ganss.Xss;

namespace Framework.Application.SecurityUtils;

public static class XssSecurity
{
    private static readonly HtmlSanitizer _htmlSanitizer;

    static XssSecurity()
    {
        _htmlSanitizer = new HtmlSanitizer
        {
            KeepChildNodes = true,
            AllowDataAttributes = true
        };

        // مثال: اگر خواستی محدودیت بیشتری بذاری:
        // _htmlSanitizer.AllowedTags.Clear();
        // _htmlSanitizer.AllowedTags.Add("b");
        // _htmlSanitizer.AllowedTags.Add("i");
    }

    public static string SanitizeText(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return "";

        return _htmlSanitizer.Sanitize(text);
    }
}
