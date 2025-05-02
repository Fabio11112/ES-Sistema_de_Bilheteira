using Microsoft.AspNetCore.Identity;
using SistemaDeBilheteira.Services.Database.Repositories;

namespace SistemaDeBilheteira.Services.Database.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IDbItem;
    void BeginTransaction();
    void Commit();
    void Rollback();
    void SaveChanges();
}

