using Microsoft.AspNetCore.Identity;
using SistemaDeBilheteira.Services.Database.Repositories;

namespace SistemaDeBilheteira.Services.Database.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity>? GetRepository<TEntity>() where TEntity : IdentityUser, IDbItem;

    void Begin();
    void Commit();
    void Rollback();
    
    void SaveChanges();
}
