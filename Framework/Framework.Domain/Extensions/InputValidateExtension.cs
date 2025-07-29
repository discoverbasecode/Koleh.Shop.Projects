using System.Globalization;
using System.Text.RegularExpressions;

namespace Framework.Domain.Extensions;

public static class InputValidateExtension
{
    public static bool IsValidEmail(this string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Normalize the domain
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                RegexOptions.None, TimeSpan.FromMilliseconds(200));

            // Examines the domain part of the email and normalizes it.
            string DomainMapper(Match match)
            {
                // Use IdnMapping class to convert Unicode domain names.
                var idn = new IdnMapping();

                // Pull out and process domain name (throws ArgumentException on invalid)
                string domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
        catch (ArgumentException)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    public static bool IsValidUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            return false;

        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }

    public static bool IsValidSlug(string slug)
    {
        if (string.IsNullOrWhiteSpace(slug))
            return false;

        // Slug should not contain spaces and should be lowercase
        return slug.All(c => char.IsLower(c) || c == '-' || char.IsLetterOrDigit(c));
    }

    public static bool IsUniCode(this string value)
    {
        return value.Any(c => c > 255);
    }

    public static bool IsText(this string value)
    {
        var isNumber = Regex.IsMatch(value, @"^\d+$");
        return !isNumber;
    }

    public static bool IsValidPhoneNumber(this string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return false;

        if (phoneNumber.IsText())
            return false;

        if (phoneNumber.Length != 11)
            return false;

        return true;
    }

    public static string SetUnReadableEmail(this string? email)
    {
        if (email == null)
        {
            return "";
        }

        email = email.Split('@')[0];
        var emailLength = email.Length;
        return "..." + email.Substring(0, Math.Max(0, emailLength - 2));
    }

    public static string SubStringCustom(this string text, int length)
    {
        if (text.Length > length)
        {
            return text.Substring(0, length - 3) + "...";
        }

        return text;
    }

    public static bool IsValidNationalId(string nationalId)
    {
        var isNumber = Regex.IsMatch(nationalId, @"^\d+$");
        if (isNumber == false)
            return false;

        var code = nationalId;

        if (Regex.IsMatch(code, @"/^\d{10}$/")) return false;
        code = ("0000" + code).Substring(code.Length + 4 - 10);

        if (Convert.ToInt32(code.Substring(3, 6), 10) == 0) return false;

        var lastNumber = Convert.ToInt32(code.Substring(9, 1), 10);
        var sum = 0;

        for (var i = 0; i < 9; i++)
        {
            sum += Convert.ToInt32(code.Substring(i, 1), 10) * (10 - i);
        }

        sum = sum % 11;

        return sum < 2 && lastNumber == sum || sum >= 2 && lastNumber == 11 - sum;
    }
}