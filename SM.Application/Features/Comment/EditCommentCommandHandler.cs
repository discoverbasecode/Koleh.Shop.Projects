using Ardalis.Result;
using Framework.Application.MediatR.Command.Handlers;
using SM.Application.Contracts.Features.Comment;
using SM.Domain.CommentAgg.Repository;

namespace SM.Application.Features.Comment;

public class EditCommentCommandHandler(ICommentRepository commentRepository) : IBaseCommandHandler<EditCommentCommand>
{
    public async Task<Result> Handle(EditCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await commentRepository.GetByIdAsync(request.CommentId, cancellationToken);
        if (comment == null)
            return Result.NotFound();

        comment.Edit(request.Text);
        await commentRepository.AddAsync(comment, cancellationToken);
        await commentRepository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
