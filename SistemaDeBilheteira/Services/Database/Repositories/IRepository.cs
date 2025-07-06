namespace SistemaDeBilheteira.Services.Database.Repositories;

public interface IRepository<TEntity> where TEntity : DbItem
{
    List<TEntity> GetAll();
    ICollection<TEntity>? GetWithQuery(Func<IQueryable<TEntity>, IQueryable<TEntity>> queryBuilder);
    TEntity? Get(Guid id);
    void Insert(TEntity item);
    void Update(TEntity item);
    void Delete(TEntity item);
}