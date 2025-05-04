using SistemaDeBilheteira.Services.Database.Context;
using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.Entities.Payment;
using SistemaDeBilheteira.Services.Database.Repositories;
using SistemaDeBilheteira.Services.Database.UnitOfWork;
using Xunit;

namespace SistemaDeBilheteira.Tests.Database;

public class ShoppingCartItemTests
{
    private Address Address;
    private SistemaDeBilheteiraContext Context;
    private IRepositoryFactory Factory;
    private IUnitOfWork UnitOfWork;
    private IRepository<Address> AdressRepository;
    private readonly SistemaDeBilheteiraContext _context;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoryFactory _repositoryFactory;

    public ShoppingCartItemTests()
    {
        Address = new Address()
        {
            City = "London",
            Country = "England",
            IsDefault = true,
            State = "Washington",
            StreetLine1 = "London",
            ZipCode = "12345"
        };
        
        Context = new MemorySistemaDeBilheteiraContext();
        Context.Database.EnsureCreated();
        
        Factory = new RepositoryFactory(Context);
        UnitOfWork = new UnitOfWork(Context, Factory);

        AdressRepository = UnitOfWork.GetRepository<Address>();
        
        UnitOfWork.Begin();
        AdressRepository.Insert(Address);
        
        UnitOfWork.SaveChanges();
    }

    [Fact]
    public void Should_Add_ShoppingCartItem_When_UnitOfWorkCommits()
    {
        // Arrange
        var user = new AppUser { Id = "user1", UserName = "TestUser" };
        var product = new Product { Id = Guid.NewGuid(), Title = "Test Product" };

        _context.Users.Add(user);
        _context.Products.Add(product);
        _context.SaveChanges();

        var cartItem = new ShoppingCartItem
        {
            AppUserId = user.Id,
            ProductId = product.Id,
            Quantity = 2
        };

        var shoppingCartRepo = _unitOfWork.GetRepository<ShoppingCartItem>();

        // Act
        _unitOfWork.Begin();
        shoppingCartRepo.Insert(cartItem);
        _unitOfWork.SaveChanges();
        _unitOfWork.Commit();

        var users = AdressRepository.GetAll();
        Assert.Single(users);
        var items = shoppingCartRepo.GetAll().ToList();

        // Assert
        Assert.Single(items);
        Assert.Equal(user.Id, items[0].AppUserId);
        Assert.Equal(product.Id, items[0].ProductId);
    }

    [Fact]
    public void Should_Not_Add_ShoppingCartItem_When_UnitOfWorkRollsBack()
    {
        // Arrange
        var user = new AppUser { Id = "user2", UserName = "RollbackUser" };
        var product = new Product { Id = Guid.NewGuid(), Title = "Rollback Product" };

        _context.Users.Add(user);
        _context.Products.Add(product);
        _context.SaveChanges();

        var cartItem = new ShoppingCartItem
        {
            AppUserId = user.Id,
            ProductId = product.Id,
            Quantity = 1
        };

        var shoppingCartRepo = _unitOfWork.GetRepository<ShoppingCartItem>();

        // Act
        _unitOfWork.Begin();
        shoppingCartRepo.Insert(cartItem);
        _unitOfWork.SaveChanges();
        _unitOfWork.Rollback();

        var items = shoppingCartRepo.GetAll().ToList();

        // Assert
        Assert.Empty(items);
    }
}

public class PaymentTests
    {
        private readonly SistemaDeBilheteiraContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryFactory _repositoryFactory;

        public PaymentTests()
        {
            _context = new MemorySistemaDeBilheteiraContext();
            _context.Database.EnsureCreated();

            _repositoryFactory = new RepositoryFactory(_context);
            _unitOfWork = new UnitOfWork(_context, _repositoryFactory);
        }

        [Fact]
        public void Should_Add_Payment_When_UnitOfWorkCommits()
        {
            // Arrange
            var user = new AppUser { Id = "user1", UserName = "PaymentUser" };
            var card = new Card
            {
                AppUserId = user.Id,
                CardHolderName = "Test Card",
                CardNumber = "4111111111111111",
                ExpirationDate = DateTime.UtcNow.AddYears(2),
                Cvv = "123"
            };
            var currency = new Currency
            {
                CurrencyCode = "EUR",
                CurrencyName = "Euro",
                CurrencySymbol = "€",
                MinorUnit = 2
            };

            _context.Users.Add(user);
            _context.PaymentMethods.Add(card);
            _context.Currencies.Add(currency);
            _context.SaveChanges();

            var payment = new Payment
            {
                PaymentMethodId = card.Id,
                PaymentMethod = card,
                Amount = 50.00m,
                CurrencyId = currency.Id,
                Currency = currency
            };

            var paymentRepo = _unitOfWork.GetRepository<Payment>();

            // Act
            _unitOfWork.Begin();
            paymentRepo.Insert(payment);
            _unitOfWork.SaveChanges();
            _unitOfWork.Commit();

            var payments = paymentRepo.GetAll().ToList();

            // Assert
            Assert.Single(payments);
            Assert.Equal(card.Id, payments[0].PaymentMethodId);
            Assert.Equal(currency.Id, payments[0].CurrencyId);
            Assert.Equal(50.00m, payments[0].Amount);
        }

        [Fact]
        public void Should_Not_Add_Payment_When_UnitOfWorkRollsBack()
        {
            // Arrange
            var user = new AppUser { Id = "user2", UserName = "RollbackPaymentUser" };
            var card = new Card
            {
                AppUserId = user.Id,
                CardHolderName = "Rollback Card",
                CardNumber = "4222222222222222",
                ExpirationDate = DateTime.UtcNow.AddYears(1),
                Cvv = "321"
            };
            var currency = new Currency
            {
                CurrencyCode = "USD",
                CurrencyName = "US Dollar",
                CurrencySymbol = "$",
                MinorUnit = 2
            };

            _context.Users.Add(user);
            _context.PaymentMethods.Add(card);
            _context.Currencies.Add(currency);
            _context.SaveChanges();

            var payment = new Payment
            {
                PaymentMethodId = card.Id,
                PaymentMethod = card,
                Amount = 100.00m,
                CurrencyId = currency.Id,
                Currency = currency
            };

            var paymentRepo = _unitOfWork.GetRepository<Payment>();

            // Act
            _unitOfWork.Begin();
            paymentRepo.Insert(payment);
            _unitOfWork.SaveChanges();
            _unitOfWork.Rollback();

            var payments = paymentRepo.GetAll().ToList();

            // Assert
            Assert.Empty(payments);
        }
    }

    public void WhenAddingServersInDatabase_TheyAreNotStoredIfFailed()
    {
        UnitOfWork.Rollback();
        
        var adresses = AdressRepository.GetAll();
        Assert.Empty(adresses);
    }
}