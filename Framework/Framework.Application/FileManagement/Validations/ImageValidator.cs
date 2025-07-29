using System.Drawing;
using Microsoft.AspNetCore.Http;

namespace Framework.Application.FileManagement.Validations;

public static class ImageValidator
{
    private const long MaxFileSize = 5 * 1024 * 1024;

    private static readonly HashSet<string> ValidExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".svg", ".webp"
    };

    private static readonly HashSet<string> ValidContentTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "image/jpeg", "image/png", "image/bmp",
        "image/gif", "image/svg+xml", "image/webp"
    };

    public static bool IsValidImage(this IFormFile? file)
    {
        if (file == null)
            return false;

        if (file.Length == 0 || file.Length > MaxFileSize)
            return false;

        var ext = Path.GetExtension(file.FileName);
        if (!ValidExtensions.Contains(ext))
            return false;

        if (!ValidContentTypes.Contains(file.ContentType))
            return false;
        try
        {
            using var image = Image.FromStream(file.OpenReadStream());
            return true;
        }
        catch
        {
            return false;
        }
    }
}