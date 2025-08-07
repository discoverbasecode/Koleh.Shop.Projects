using Framework.Domain.Common;
using Framework.Domain.Exceptions;

namespace SM.Domain.CommentAgg;

public class Comment : AggregateRoot
{
    public Guid UserId { get; private set; }
    public Guid ProductId { get; private set; }
    public string Text { get; private set; }
    public string RejectedText { get; private set; }
    public CommentStatus Status { get; private set; }

    public Comment(Guid userId, Guid productId, string text, string rejectedText)
    {
        Guards(text);
        UserId = userId;
        ProductId = productId;
        Text = text;
        RejectedText = rejectedText;
        Status = CommentStatus.Pending;
    }

    public void Edit(string text)
    {
        Guards(text);
        Text = text;
        UpdatedAt = DateTime.Now;
    }

    public void ChangeStatus(CommentStatus status)
    {
        Status = status;
        UpdatedAt = DateTime.Now;
    }

    private void Guards(string text)
    {
        if (Text == text)
            throw InvalidFieldException.Create("متن", DomainMessageTemplate.NotEmpty);
        if (text.Length < 5)
            throw InvalidFieldException.Create("متن", DomainMessageTemplate.MinLength);
        if (text.Length < 1000)
            throw InvalidFieldException.Create("متن", DomainMessageTemplate.MaxLength);
    }
}

public enum CommentStatus
{
    Pending,
    Accepted,
    Rejected,
}