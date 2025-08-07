using Ardalis.Result;
using Framework.Application.MediatR.Command.Interfaces;

namespace SM.Application.Contracts.Features.Comment;

public record CreateCommentCommand(
    Guid UserId,
    Guid ProductId,
    string Text,
    string RejectedText) : IBaseCommand;
