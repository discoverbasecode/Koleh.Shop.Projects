using Ardalis.Result;
using Framework.Application.MediatR.Command.Handlers;
using SM.Application.Contracts.Features.Comment;
using SM.Domain.CommentAgg.Repository;

namespace SM.Application.Features.Comment;

public class CreateCommentCommandHandler(ICommentRepository commentRepository) : IBaseCommandHandler<CreateCommentCommand>
{
    public async Task<Result> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new Domain.CommentAgg.Comment(request.UserId, request.ProductId, request.Text, request.RejectedText);

        await commentRepository.AddAsync(comment, cancellationToken);
        await commentRepository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
