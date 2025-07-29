namespace Framework.Application.MediatR.Queries.Pagination;

public class BaseFilter
{
    public long EntityCount { get; private set; }
    public int CurrentPage { get; private set; }
    public int PageCount { get; private set; }
    public int StartPage { get; private set; }
    public int EndPage { get; private set; }
    public int Take { get; private set; }

    public void GeneratePaging<T>(IQueryable<T> data, int take, int currentPage)
    {
        var totalCount = data.Count();
        GeneratePaging(totalCount, take, currentPage);
    }

    public void GeneratePaging(long totalCount, int take, int currentPage)
    {
        var pageCount = (int)Math.Ceiling(totalCount / (double)take);
        SetPaging(totalCount, pageCount, take, currentPage);
    }

    public void GeneratePaging(long totalCount, int pageCount, int take, int currentPage)
    {
        SetPaging(totalCount, pageCount, take, currentPage);
    }

    private void SetPaging(long totalCount, int pageCount, int take, int currentPage)
    {
        EntityCount = totalCount;
        PageCount = pageCount;
        Take = take;
        CurrentPage = currentPage;

        StartPage = Math.Max(currentPage - 4, 1);
        EndPage = Math.Min(currentPage + 5, pageCount);
    }
}
