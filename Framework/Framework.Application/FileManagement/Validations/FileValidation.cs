using Microsoft.AspNetCore.Http;

namespace Framework.Application.FileManagement.Validations;

public static class FileValidation
{
    private static readonly HashSet<string> ValidExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".mp4", ".mp3", ".zip", ".rar", ".wav", ".docx", ".mmf", ".m4a", ".ogg",
        ".doc", ".pdf", ".txt", ".xls", ".xla", ".xlsx", ".ppt", ".pptx", ".gif",
        ".jpg", ".png", ".tif", ".wmv", ".bmp", ".wmf", ".log"
    };

    private static readonly HashSet<string> CompressExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".zip", ".rar"
    };

    private static readonly HashSet<string> ImageExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".jpg", ".jpeg", ".png", ".bmp", ".svg", ".webp"
    };

    public static bool IsValidFile(this IFormFile? file) =>
        file != null && IsValidExtension(file.FileName, ValidExtensions);

    public static bool IsValidCompressFile(this IFormFile? file) =>
        file != null && IsValidExtension(file.FileName, CompressExtensions);

    public static bool IsValidMp4File(this IFormFile? file) =>
        file != null && Path.GetExtension(file.FileName).Equals(".mp4", StringComparison.OrdinalIgnoreCase);

    public static bool IsValidImageFile(this string fileName) =>
        !string.IsNullOrWhiteSpace(fileName) && IsValidExtension(fileName, ImageExtensions);

    private static bool IsValidExtension(string fileName, HashSet<string> allowedExtensions)
    {
        var ext = Path.GetExtension(fileName);
        return !string.IsNullOrWhiteSpace(ext) && allowedExtensions.Contains(ext);
    }
}