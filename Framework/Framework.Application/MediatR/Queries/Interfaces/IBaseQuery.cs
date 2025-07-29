using Framework.Application.MediatR.Queries.Pagination;
using MediatR;

namespace Framework.Application.MediatR.Queries.Interfaces;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}

public class QueryFilter<TResponse, TParam> : IQuery<TResponse> where TResponse : BaseFilter where TParam : BaseFilterParam
{
    public TParam FilterParams { get; set; }
    public QueryFilter(TParam filterParams)
    {
        FilterParams = filterParams;
    }
}