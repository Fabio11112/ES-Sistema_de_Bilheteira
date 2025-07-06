using SistemaDeBilheteira.Services.Database;
using IResult = SistemaDeBilheteira.Services.AuthenticationService.IResult;

namespace SistemaDeBilheteira.Services.IService;

/*
 * IService is a generic interface that defines the basic operations for a service.
 * It provides methods for adding, deleting, updating, and retrieving items.
 * The generic type parameter T allows for different types of items to be used with the service.
 */
public interface IService<T> where T : DbItem
{
    IResult Add(T item);
    IResult Delete(T item);
    IResult Update(T item);
    T? GetById(Guid id);
    ICollection<T>? GetAll();
    ICollection<T>? GetWithQuery(Func<IQueryable<T>, IQueryable<T>> queryBuilder);
}