using SistemaDeBilheteira.Services.Database;
using SistemaDeBilheteira.Services.Database.UnitOfWork;
using SistemaDeBilheteira.Services.IService;

namespace SistemaDeBilheteira.Services.AuthenticationService.IService;

/**
 * Service is a generic class that implements the IService interface.
 * It provides the basic operations for a service, such as adding, deleting, updating, and retrieving items.
 * The generic type parameter T allows for different types of items to be used with the service.
 */
public class Service<T>(IUnitOfWork unitOfWork) : IService<T> where T : DbItem
{
    private IUnitOfWork UnitOfWork { get; set; } = unitOfWork;


    //Add method to add an item to the database.
    public IResult Add(T item)
    {
        IResult result = new Result();

        var repository = UnitOfWork.GetRepository<T>();

        if (repository == null)
        {
            result.Success = false;
            result.Message = "Internal Server Error";
            return result;
        }

        UnitOfWork.Begin();
        repository.Insert(item);
        UnitOfWork.SaveChanges();
        UnitOfWork.Commit();

        result.Success = true;
        result.Message = "Address added successfully";
        return result;
    }

    //Add method to DELETE an item to the database.
    public IResult Delete(T? item)
    {
        IResult result = new Result();

        var repository = UnitOfWork.GetRepository<T>();

        if (repository == null)
        {
            result.Success = false;
            result.Message = "Internal Server Error | Null item";
            return result;
        }

        if (item == null)
        {

            result.Success = false;
            result.Message = $"There is no {typeof(T)} with this ID";
            return result;
        }

        UnitOfWork.Begin();
        repository.Delete(item);
        UnitOfWork.SaveChanges();
        UnitOfWork.Commit();


        result.Success = true;
        result.Message = "Address deleted successfully";
        return result;
    }

    //Add method to UPDATE an item to the database.
    public IResult Update(T item)
    {
        IResult result = new Result();
        var repository = UnitOfWork.GetRepository<T>();
        if (repository == null)
        {
            result.Success = false;
            result.Message = "Internal Server Error";
            return result;
        }

        UnitOfWork.Begin();
        repository.Update(item);
        UnitOfWork.SaveChanges();
        UnitOfWork.Commit();


        result.Success = true;
        result.Message = "Address updated successfully";
        return result;
    }

    //Add method to GET an item by ID from the database.
    public T? GetById(Guid id)
    {
        var repository = UnitOfWork.GetRepository<T>();
        if (repository == null)
        {
            return null;
        }
        return repository.Get(id);
    }

    //Add method to GET all items from the database.
    public ICollection<T>? GetAll()
    {
        var repository = UnitOfWork.GetRepository<T>();
        if (repository == null)
        {
            return null;
        }

        return repository.GetAll();
    }

    //Add method to GET all items with a query from the database.
    public ICollection<T>? GetWithQuery(Func<IQueryable<T>, IQueryable<T>> queryBuilder)
    {
        var repository = UnitOfWork.GetRepository<T>();
        if (repository == null)
        {
            return null;
        }
        return repository.GetWithQuery(queryBuilder);
    }
}