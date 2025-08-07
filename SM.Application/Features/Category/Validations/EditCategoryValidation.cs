using FluentValidation;
using Framework.Application.ValidationExtensions;
using SM.Application.Contracts.Features.Category;

namespace SM.Application.Features.Category.Validations;

public class EditCategoryValidation : AbstractValidator<CreateCategoryCommand>
{
    public EditCategoryValidation()
    {
        RuleFor(c => c.Title)
            .NotEmpty()
            .WithMessage(c =>
                ValidationMessages.RequiredField(nameof(c.Title)));

        RuleFor(c => c.Slug)
            .NotEmpty()
            .WithMessage(c =>
                ValidationMessages.RequiredField(nameof(c.Slug)));
    }
}