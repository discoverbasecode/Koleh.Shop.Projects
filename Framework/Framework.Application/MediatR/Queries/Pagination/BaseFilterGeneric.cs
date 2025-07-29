namespace Framework.Application.MediatR.Queries.Pagination;

public class BaseFilter<TData> : BaseFilter where TData : class
{
    public List<TData> Data { get; set; } = new();
}
