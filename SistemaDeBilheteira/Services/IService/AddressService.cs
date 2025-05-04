using SistemaDeBilheteira.Services.AuthenticationService;
using SistemaDeBilheteira.Services.AuthenticationService.IService;
using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.UnitOfWork;
using IResult = SistemaDeBilheteira.Services.AuthenticationService.IResult;

namespace SistemaDeBilheteira.Services.IService;

public class AddressService(IUnitOfWork unitOfWork) : Service<Address>(unitOfWork)
{
    public override IResult Add(Address item)
    {
        IResult result = new Result();
        
        var repository = UnitOfWork.GetRepository<Address>();
        
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

    public override IResult Delete(Guid id)
    {
        IResult result = new Result();
        
        var repository = UnitOfWork.GetRepository<Address>();
        
        if (repository == null)
        {
            result.Success = false;
            result.Message = "Internal Server Error";
            return result;
        }
        
        UnitOfWork.Begin();
        var address = repository.Get(id);

        if (address == null)
        {
            UnitOfWork.Commit();
            result.Success = false;
            result.Message = "There is no address with this ID";
            return result;
        }
        repository.Delete(address);
        UnitOfWork.SaveChanges();
        UnitOfWork.Commit();
        
        
        result.Success = true;
        result.Message = "Address deleted successfully";
        return result;
    }

    public override IResult Update(Address item)
    {
        IResult result = new Result();
        var repository = UnitOfWork.GetRepository<Address>();
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

    public override Address? GetById(Guid id)
    {
        var repository = UnitOfWork.GetRepository<Address>();
        if (repository == null)
        {
            return null;
        }
        return repository.Get(id);
        
    }

    public override ICollection<Address>? GetAll()
    {
        var repository = UnitOfWork.GetRepository<Address>();
        if (repository == null)
        {
            return null;
        }
        
        return repository.GetAll();
    }

}