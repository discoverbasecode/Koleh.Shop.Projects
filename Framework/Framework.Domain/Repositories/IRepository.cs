using System.Linq.Expressions;

namespace Framework.Domain.Repositories;

public interface IRepository<T> where T : class
{
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<TResult>> ProjectAsync<TResult>(
        Expression<Func<T, bool>> filter,
        Expression<Func<T, TResult>> selector,
        CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);

    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>? orderBy = null,
        bool orderByDescending = false,
        CancellationToken cancellationToken = default);

    Task ReloadAsync(T entity, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAllNoTrackingAsync(CancellationToken cancellationToken = default);
}