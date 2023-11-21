namespace Students.APIServer.Repository;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity> Create(TEntity item);
    Task<TEntity> FindById(Guid id);
    Task<IEnumerable<TEntity>> Get();
    Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> predicate);
    Task Remove(TEntity item);
    Task<TEntity> Update(TEntity item);
}