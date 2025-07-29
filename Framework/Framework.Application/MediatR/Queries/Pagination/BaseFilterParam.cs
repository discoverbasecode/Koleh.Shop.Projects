namespace Framework.Application.MediatR.Queries.Pagination;

public abstract class BaseFilterParam
{
    public int PageId { get; set; } = 1;
    public int Take { get; set; } = 10;
    public int Skip => (PageId - 1) * Take;
}
