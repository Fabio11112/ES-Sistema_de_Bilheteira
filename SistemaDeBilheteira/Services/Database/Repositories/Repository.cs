using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SistemaDeBilheteira.Services.Database.Context;

namespace SistemaDeBilheteira.Services.Database.Repositories;

public class Repository<TEntity>(SistemaDeBilheteiraContext context) : IRepository<TEntity> where TEntity : DbItem
{
    private readonly SistemaDeBilheteiraContext _context = context;
    
    public List<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public ICollection<TEntity>? GetWithQuery(Func<IQueryable<TEntity>, IQueryable<TEntity>> queryBuilder)
    {
        var dbSet = _context.Set<TEntity>();
        var query = queryBuilder(dbSet);
        return query.ToList();
    }

    public TEntity? Get(Guid id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public void Insert(TEntity item)
    {
        _context.Set<TEntity>().Add(item);
    }

    public void Update(TEntity item)
    {
        _context.Entry(item).State = EntityState.Modified;
    }

    public void Delete(TEntity item)
    {
        _context.Remove(item);
    }
}

