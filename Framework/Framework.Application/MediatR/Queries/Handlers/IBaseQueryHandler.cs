using Framework.Application.MediatR.Queries.Interfaces;
using MediatR;

namespace Framework.Application.MediatR.Queries.Handlers;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
{

}