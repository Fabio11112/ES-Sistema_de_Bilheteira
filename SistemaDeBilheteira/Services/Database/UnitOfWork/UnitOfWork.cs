using Microsoft.EntityFrameworkCore.Storage;
using SistemaDeBilheteira.Services.Database.Context;
using SistemaDeBilheteira.Services.Database.Repositories;

namespace SistemaDeBilheteira.Services.Database.UnitOfWork;

public class UnitOfWork(SistemaDeBilheteiraContext context, IRepositoryFactory repositoryFactory): IUnitOfWork
{


    private IDbContextTransaction? Transaction { get; set; }

    private IRepositoryFactory RepositoryFactory { get; set; } = repositoryFactory;
    private SistemaDeBilheteiraContext Context { get; set; } = context;
    
    private IDictionary<Type, Object> Repositories { get; } = new Dictionary<Type, Object>();

    public void Dispose()
    {
        Context.Dispose();
        Transaction?.Dispose();
        Context.Dispose();
    }
    

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : DbItem
    {
        if (!Repositories.ContainsKey(typeof(TEntity)))
        {
            Repositories[typeof(TEntity)] = RepositoryFactory.Create<TEntity>();
        }

        return (IRepository<TEntity>)Repositories[typeof(TEntity)];
    }

    public void Begin()
    {
        Transaction = Context.Database.BeginTransaction();
    }

    public void Commit()
    {
        Transaction?.Commit();
        Transaction = null;
    }

    public void Rollback()
    {
        Transaction?.Rollback();
        Transaction = null;
    }

    public void SaveChanges()
    {
        Context.SaveChanges();
    }
}