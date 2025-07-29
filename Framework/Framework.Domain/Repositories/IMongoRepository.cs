using Framework.Domain.Entities;

namespace Framework.Domain.Repositories;

public interface IMongoRepository<TEntity> where TEntity : BaseEntity
{
    Task Delete(Guid id);
    Task<TEntity?> GetById(Guid id);
    Task<List<TEntity>> GetAll();
    Task Insert(TEntity entity);
    Task Update(TEntity entity);
}
