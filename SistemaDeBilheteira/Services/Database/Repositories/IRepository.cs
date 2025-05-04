namespace SistemaDeBilheteira.Services.Database.Repositories;

public interface IRepository<TEntity> where TEntity : class, IDbItem
{
        
    List<TEntity> GetAll();
    TEntity? Get(Guid id);
    void Insert(TEntity item);
    void Update(TEntity item);
    void Delete(TEntity item);
}