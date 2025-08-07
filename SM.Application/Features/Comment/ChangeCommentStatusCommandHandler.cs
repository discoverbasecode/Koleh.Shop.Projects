
using Ardalis.Result;
using Framework.Application.MediatR.Command.Handlers;
using SM.Application.Contracts.Features.Comment;
using SM.Domain.CommentAgg.Repository;

namespace SM.Application.Features.Comment;

public class ChangeCommentStatusCommandHandler(ICommentRepository commentRepository) : IBaseCommandHandler<ChangeCommentStatusCommand>
{
    public async Task<Result> Handle(ChangeCommentStatusCommand request, CancellationToken cancellationToken)
    {
        var comment = await commentRepository.GetByIdAsync(request.CommentId, cancellationToken);
        if (comment == null)
            return Result.NotFound();

        comment.ChangeStatus(request.Status);
        commentRepository.Update(comment);
        await commentRepository.SaveChangesAsync(cancellationToken);

        return Result.Success();

    }
}
