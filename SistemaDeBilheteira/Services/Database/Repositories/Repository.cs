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

    /*
     * This method is used to get a collection of entities based on a query.
     * The query is built using a Func delegate that takes an IQueryable<TEntity> and returns an IQueryable<TEntity>.
     * The query is then executed and the results are returned as a list.
     */
    public ICollection<TEntity> GetWithQuery(Func<IQueryable<TEntity>, IQueryable<TEntity>> queryBuilder)
    {
        if (queryBuilder == null) throw new ArgumentNullException(nameof(queryBuilder));

        var dbSet = _context.Set<TEntity>();
        var query = queryBuilder(dbSet);
        return query.ToList();
    }

    /*
     * This method is used to get a single entity by its ID.
     * It uses the Find method of the DbSet to retrieve the entity from the database.
     */
    public TEntity? Get(Guid id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    /*
     * This method is used to insert a new entity into the database.
     * It uses the Add method of the DbSet to add the entity to the context.
     */
    public void Insert(TEntity item)
    {
        _context.Set<TEntity>().Add(item);
    }

    /*
     * This method is used to update an existing entity in the database.
     * It sets the state of the entity to Modified, which tells the context to update it when SaveChanges is called.
     */
    public void Update(TEntity item)
    {
        _context.Entry(item).State = EntityState.Modified;
    }

    /*
     * This method is used to delete an entity from the database.
     * It uses the Remove method of the DbSet to remove the entity from the context.
     */
    public void Delete(TEntity item)
    {
        _context.Remove(item);
    }
}

