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

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : DbItem

    {
        if (!_repositories.ContainsKey(typeof(TEntity)))
        {
            _repositories[typeof(TEntity)] = _repositoryFactory.Create<TEntity>();
        }

        return (IRepository<TEntity>)_repositories[typeof(TEntity)];
    }

    public void Begin()
    {
        _transaction = _context.Database.BeginTransaction();
    }

    public void Commit()
    {
        _transaction?.Commit();
        _transaction = null;
    }

    public void Rollback()
    {
        _transaction?.Rollback();
        _transaction = null;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void BeginTransaction()
    {
        _transaction = _context.Database.BeginTransaction();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}
