using Microsoft.EntityFrameworkCore.Metadata;
using SistemaDeBilheteira.Components.Cards.EditAdress;
using SistemaDeBilheteira.Services.Database;
using SistemaDeBilheteira.Services.Database.UnitOfWork;
using SistemaDeBilheteira.Services.IService;

namespace SistemaDeBilheteira.Services.AuthenticationService.IService;

public class Service<T>(IUnitOfWork unitOfWork) : IService<T> where T : DbItem
{
    private IUnitOfWork UnitOfWork { get; set; } = unitOfWork;


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

    public  IResult Delete(T? item)
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

    public T? GetById(Guid id)
    {
        var repository = UnitOfWork.GetRepository<T>();
        if (repository == null)
        {
            return null;
        }
        return repository.Get(id);
    }

    public ICollection<T>? GetAll()
    {
        var repository = UnitOfWork.GetRepository<T>();
        if (repository == null)
        {
            return null;
        }
        
        return repository.GetAll();
    }

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