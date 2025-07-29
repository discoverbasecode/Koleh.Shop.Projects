using System.Security.Cryptography;

namespace Framework.Application.SecurityUtils;

public static partial class PasswordHasher
{
    private const int SaltSize = 16; // 128 bit
    private const int KeySize = 32;  // 256 bit
    private const int Iterations = 10000;

    public static string HashPassword(string password)
    {
        using var rng = RandomNumberGenerator.Create();
        var salt = new byte[SaltSize];
        rng.GetBytes(salt);

        var key = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256).GetBytes(KeySize);
        var base64Salt = Convert.ToBase64String(salt);
        var base64Key = Convert.ToBase64String(key);

        return $"{Iterations}.{base64Salt}.{base64Key}";
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        var parts = hashedPassword.Split('.', 3);
        if (parts.Length != 3)
            return false;

        var iterations = int.Parse(parts[0]);
        var salt = Convert.FromBase64String(parts[1]);
        var key = Convert.FromBase64String(parts[2]);

        var incomingKey = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256).GetBytes(KeySize);
        return incomingKey.SequenceEqual(key);
    }
}
