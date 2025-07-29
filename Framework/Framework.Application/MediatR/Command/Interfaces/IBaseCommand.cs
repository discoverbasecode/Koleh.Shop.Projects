using Ardalis.Result;
using MediatR;

namespace Framework.Application.MediatR.Command.Interfaces;

public interface IBaseCommand : IRequest<Result>
{
}

public interface IBaseCommand<TData> : IRequest<Result<TData>>
{
}