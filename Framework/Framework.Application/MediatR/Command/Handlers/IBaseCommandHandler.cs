using Ardalis.Result;
using Framework.Application.MediatR.Command.Interfaces;
using MediatR;

namespace Framework.Application.MediatR.Command.Handlers
{
    public interface IBaseCommandHandler<TCommand> : IRequestHandler<TCommand, Result>
        where TCommand : IBaseCommand, IRequest<Result>
    {
    }

    public interface IBaseCommandHandler<TCommand, TResponseData> : IRequestHandler<TCommand, Result<TResponseData>>
        where TCommand : IBaseCommand<TResponseData>, IRequest<Result<TResponseData>>
    {
    }
}