﻿using Microsoft.EntityFrameworkCore.Storage;
using SistemaDeBilheteira.Services.Database.Context;
using SistemaDeBilheteira.Services.Database.Repositories;

namespace SistemaDeBilheteira.Services.Database.UnitOfWork;

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

    /*
     * This method is used to get a repository for a specific entity type.
     * It checks if the repository already exists in the dictionary, and if not, it creates a new one.
     * The repository is then stored in the dictionary for future use.
     */
    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : DbItem

    {
        if (!_repositories.ContainsKey(typeof(TEntity)))
        {
            _repositories[typeof(TEntity)] = _repositoryFactory.Create<TEntity>();
        }

        return (IRepository<TEntity>)_repositories[typeof(TEntity)];
    }
    //initialization of the transaction
    public void Begin()
    {
        _transaction = _context.Database.BeginTransaction();
    }

    //commit the transaction
    public void Commit()
    {
        _transaction?.Commit();
        _transaction = null;
    }

    //rollback the transaction
    public void Rollback()
    {
        _transaction?.Rollback();
        _transaction = null;
    }

    //save changes to the database
    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    //begin a new transaction
    public void BeginTransaction()
    {
        _transaction = _context.Database.BeginTransaction();
    }

    //commit the transaction
    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}
