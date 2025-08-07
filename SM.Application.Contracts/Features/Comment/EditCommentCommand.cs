using Framework.Application.MediatR.Command.Interfaces;

namespace SM.Application.Contracts.Features.Comment;

public record EditCommentCommand(
    Guid CommentId,
    Guid UserId,
    Guid ProductId,
    string Text,
    string RejectedText) : IBaseCommand;
