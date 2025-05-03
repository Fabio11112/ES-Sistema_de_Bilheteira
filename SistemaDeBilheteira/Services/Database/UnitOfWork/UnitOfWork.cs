// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore.Storage;
// using SistemaDeBilheteira.Services.Database.Context;
// using SistemaDeBilheteira.Services.Database.Repositories;

// namespace SistemaDeBilheteira.Services.Database.UnitOfWork;

// public class UnitOfWork(SistemaDeBilheteiraContext context, IRepositoryFactory repositoryFactory): IUnitOfWork
// {
//     private IDbContextTransaction? Transaction { get; set; }
//     private IRepositoryFactory RepositoryFactory { get; set; } = repositoryFactory;
//     private SistemaDeBilheteiraContext Context { get; set; } = context;
    
//     private IDictionary<Type, Object> Repositories { get; } = new Dictionary<Type, Object>();

//     public void Dispose()
//     {
//         Context.Dispose();
//         Transaction?.Dispose();
//         Context.Dispose();
//     }
    

//     public IRepository<TEntity> GetRepository<TEntity>() where TEntity : IdentityUser, IDbItem
//     {
//         if (!Repositories.ContainsKey(typeof(TEntity)))
//         {
//             Repositories[typeof(TEntity)] = RepositoryFactory.Create<TEntity>();
//         }

//         return (IRepository<TEntity>)Repositories[typeof(TEntity)];
//     }

//     public void Begin()
//     {
//         Transaction = Context.Database.BeginTransaction();
//     }

//     public void Commit()
//     {
//         Transaction?.Commit();
//         Transaction = null;
//     }

//     public void Rollback()
//     {
//         Transaction?.Rollback();
//         Transaction = null;
//     }

//     public void SaveChanges()
//     {
//         Context.SaveChanges();
//     }
//}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;
using SistemaDeBilheteira.Services.Database;
using SistemaDeBilheteira.Services.Database.Context;
using SistemaDeBilheteira.Services.Database.Repositories;

// Interface
public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IDbItem;
    void BeginTransaction();
    void Commit();
    void Rollback();
    void SaveChanges();
}

// Implementação
public class UnitOfWork : IUnitOfWork
{
    private readonly SistemaDeBilheteiraContext _context;
    private readonly IRepositoryFactory _repositoryFactory;
    private IDbContextTransaction? _transaction;
    private readonly IDictionary<Type, object> _repositories = new Dictionary<Type, object>();

    public UnitOfWork(SistemaDeBilheteiraContext context, IRepositoryFactory repositoryFactory)
    {
        _context = context;
        _repositoryFactory = repositoryFactory;
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : DbItem

    {
        if (!_repositories.ContainsKey(typeof(TEntity)))
        {
            _repositories[typeof(TEntity)] = _repositoryFactory.Create<TEntity>();
        }
        return (IRepository<TEntity>)_repositories[typeof(TEntity)];
    }

    public void BeginTransaction()
    {
        _transaction = _context.Database.BeginTransaction();
    }

    public void Commit()
    {
        _transaction?.Commit();
        _transaction?.Dispose();
        _transaction = null;
    }

    public void Rollback()
    {
        _transaction?.Rollback();
        _transaction?.Dispose();
        _transaction = null;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}
