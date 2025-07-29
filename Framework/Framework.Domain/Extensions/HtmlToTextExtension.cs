using System.Text.RegularExpressions;

namespace Framework.Domain.Extensions;

public static class HtmlToTextExtension
{
    public static string ToPlainText(string html)
    {
        if (string.IsNullOrEmpty(html))
        {
            return string.Empty;
        }

        // Remove HTML tags
        var text = System.Text.RegularExpressions.Regex.Replace(html, "<.*?>", string.Empty);

        // Replace multiple spaces with a single space
        text = System.Text.RegularExpressions.Regex.Replace(text, @"\s+", " ").Trim();

        return text;
    }

    public static string ConvertHtmlToText(this string text)
    {
        return Regex.Replace(text, "<.*?>", " ")
            .Replace("&zwnj;", " ")
            .Replace(";&zwnj", " ")
            .Replace("&nbsp;", " ");
    }
}