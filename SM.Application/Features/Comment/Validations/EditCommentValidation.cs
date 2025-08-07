using FluentValidation;
using Framework.Application.ValidationExtensions;
using SM.Application.Contracts.Features.Comment;

namespace SM.Application.Features.Comment.Validations;

public class EditCommentValidation : AbstractValidator<CreateCommentCommand>
{
    public EditCommentValidation()
    {
        RuleFor(c => c.Text)
            .NotEmpty().WithMessage(c => ValidationMessages.RequiredField(nameof(c.Text)))
            .MinimumLength(5).WithMessage(c => ValidationMessages.MinLengthField(nameof(c.Text), 5));

    }
}
