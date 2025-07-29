namespace Framework.Application.Paginate
{
    public class PaginateResult<T>
    {
        public int EntityCount { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageCount { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public int PageSize { get; private set; }
        public List<T> Items { get; private set; } = new List<T>();

        private PaginateResult() { }

        public static PaginateResult<T> Create(IQueryable<T> source, int pageSize, int currentPage)
        {
            var result = new PaginateResult<T>();

            result.EntityCount = source.Count();
            result.PageSize = pageSize;
            result.CurrentPage = currentPage;

            result.PageCount = (int)Math.Ceiling(result.EntityCount / (double)result.PageSize);

            result.StartPage = result.CurrentPage - 4 > 0 ? result.CurrentPage - 4 : 1;
            result.EndPage = result.CurrentPage + 5 > result.PageCount ? result.PageCount : result.CurrentPage + 5;
            
            int skip = (result.CurrentPage - 1) * result.PageSize;
            result.Items = source.Skip(skip).Take(result.PageSize).ToList();

            return result;
        }
    }
}
