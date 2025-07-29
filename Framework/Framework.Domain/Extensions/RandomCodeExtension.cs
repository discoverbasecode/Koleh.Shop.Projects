namespace Framework.Domain.Extensions;

public class RandomCodeExtension
{
    public static string GenerateRandomCode(int length = 8)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        Random random = new Random();
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    public static string GenerateRandomCodeWithPrefix(string prefix, int length = 8)
    {
        return prefix + GenerateRandomCode(length);
    }
    public static string GenerateCode(int length)
    {
        var random = new Random();
        var code = "";
        for (int i = 0; i < length; i++)
        {
            code += random.Next(0, 10).ToString();
        }
        return code;
    }

}
