using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SistemaDeBilheteira.Services.Database.Context;

namespace SistemaDeBilheteira.Services.Database.Repositories;

// public class Repository<TEntity>(SistemaDeBilheteiraContext context) : IRepository<TEntity> where TEntity : IdentityUser, IDbItem
// {
//     private readonly SistemaDeBilheteiraContext _context = context;
    
//     public List<TEntity> GetAll()
//     {
//         return _context.Set<TEntity>().ToList();
//     }

//     public TEntity? Get(Guid id)
//     {
//         return _context.Set<TEntity>().Find(id);
//     }

//     public void Insert(TEntity item)
//     {
//         _context.Set<TEntity>().Add(item);
//     }

//     public void Update(TEntity item)
//     {
//         _context.Entry(item).State = EntityState.Modified;
//     }

//     public void Delete(TEntity item)
//     {
//         _context.Remove(item);
//     }
// }

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IDbItem
{
    private readonly SistemaDeBilheteiraContext _context;

    public Repository(SistemaDeBilheteiraContext context)
    {
        _context = context;
    }

    public List<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
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
        _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    }

    public void Delete(TEntity item)
    {
        _context.Remove(item);
    }
}
