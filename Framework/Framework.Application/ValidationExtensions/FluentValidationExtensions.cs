using FluentValidation;
using Framework.Application.FileManagement.Validations;
using Framework.Domain.Extensions;
using Microsoft.AspNetCore.Http;

namespace Framework.Application.ValidationExtensions;

public static class FluentValidationExtensions
{
    public static IRuleBuilderOptionsConditions<T, TProperty> JustImageFile<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, string errorMessage = "فایل تصویر نامعتبر است")
        where TProperty : IFormFile?
    {
        return ruleBuilder.Custom((file, context) =>
        {
            if (file == null)
                return;

            if (!FileValidation.IsValidImage(file))
            {
                context.AddFailure(errorMessage);
            }
        });
    }

    public static IRuleBuilderOptionsConditions<T, string> ValidNationalId<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        string errorMessage = "کد ملی نامعتبر است")
    {
        return ruleBuilder.Custom((nationalCode, context) =>
        {
            if (!NationalIdValidator.IsValidIranianNationalId(nationalCode))
                context.AddFailure(errorMessage);
        });
    }

    public static IRuleBuilderOptionsConditions<T, string> ValidPhoneNumber<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        string errorMessage = "شماره تلفن نامعتبر است")
    {
        return ruleBuilder.Custom((phoneNumber, context) =>
        {
            if (string.IsNullOrWhiteSpace(phoneNumber) || !phoneNumber.IsValidPhoneNumber())
                context.AddFailure(errorMessage);
        });
    }

    public static IRuleBuilderOptionsConditions<T, TProperty> JustValidFile<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder,
        string errorMessage = "فایل نامعتبر است") where TProperty : IFormFile?
    {
        return ruleBuilder.Custom((file, context) =>
        {
            if (file == null)
                return;

            if (!FileValidation.IsValidFile(file))
            {
                context.AddFailure(errorMessage);
            }
        });
    }
}