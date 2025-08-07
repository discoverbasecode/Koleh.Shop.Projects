
using Framework.Application.MediatR.Command.Interfaces;
using SM.Domain.CommentAgg.Enums;
namespace SM.Application.Contracts.Features.Comment;

public record ChangeCommentStatusCommand(
Guid CommentId,
CommentStatus Status) : IBaseCommand;
