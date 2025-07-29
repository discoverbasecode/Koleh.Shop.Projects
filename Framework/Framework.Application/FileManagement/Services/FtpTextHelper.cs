namespace Framework.Application.FileManagement.Services;

public static class FtpTextHelper
{
    public static string RemoveWwwRoot(this string text) => text.Replace("wwwroot", "");
}