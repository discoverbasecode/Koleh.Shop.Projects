using Framework.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Framework.Domain.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IRepository<T> Repository<T>() where T : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    Task<DbContext> BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}