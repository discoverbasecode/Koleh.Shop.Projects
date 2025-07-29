namespace Framework.Application.ValidationExtensions;

using FluentValidation;

public static class NationalIdValidator
{
    public static bool IsValidIranianNationalId(string nationalCode)
    {
        if (string.IsNullOrWhiteSpace(nationalCode) || nationalCode.Length != 10 || !nationalCode.All(char.IsDigit))
            return false;

        var digits = nationalCode.Select(c => int.Parse(c.ToString())).ToArray();

        if (digits.All(d => d == digits[0]))
            return false;
        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            sum += digits[i] * (10 - i);
        }

        int remainder = sum % 11;
        int checkDigit = digits[9];

        if (remainder < 2)
            return checkDigit == remainder;
        else
            return checkDigit == 11 - remainder;
    }
}