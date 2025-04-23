using Microsoft.EntityFrameworkCore;
using SistemaDeBilheteira.Services.Database.Context;

namespace SistemaDeBilheteira.Services.Database.Entities.Repositories;

public interface IRepository<TEntity> where TEntity : DbItem
{
        
    List<TEntity> GetAll();
    TEntity? Get(Guid id);
    void Insert(TEntity item);
    void Update(TEntity item);
    void Delete(TEntity item);
}