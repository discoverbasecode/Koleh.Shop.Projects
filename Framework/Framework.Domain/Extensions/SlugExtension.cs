namespace Framework.Domain.Extensions;

public static class SlugExtension
{

    public static string ToSlug(this string url)
    {
        return url.Trim().ToLower()
            .Replace("$", "")
            .Replace("+", "")
            .Replace("%", "")
            .Replace("?", "")
            .Replace("^", "")
            .Replace("*", "")
            .Replace("@", "")
            .Replace("!", "")
            .Replace("#", "")
            .Replace("&", "")
            .Replace("~", "")
            .Replace("(", "")
            .Replace("=", "")
            .Replace(")", "")
            .Replace("/", "")
            .Replace(@"\", "")
            .Replace(".", "")
            .Replace(" ", "-");
    }

}
