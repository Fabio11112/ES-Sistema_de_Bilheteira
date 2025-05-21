using Microsoft.EntityFrameworkCore;
using SistemaDeBilheteira.Services.Database.Context;
using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.Entities.PaymentSystem;
using SistemaDeBilheteira.Services.Database.Repositories;
using SistemaDeBilheteira.Services.Database.UnitOfWork;

namespace SistemaDeBilheteira.Tests.Database;

public class PaypalPaymentTests
{
    private readonly SistemaDeBilheteiraContext _context;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoryFactory _repositoryFactory;

    public PaypalPaymentTests()
    {
        _context = new MemorySistemaDeBilheteiraContext(new DbContextOptionsBuilder<SistemaDeBilheteiraContext>().Options);
        _context.Database.EnsureCreated();
        
        _context.Database.EnsureCreated();

        _repositoryFactory = new RepositoryFactory(_context);
        _unitOfWork = new UnitOfWork(_context, _repositoryFactory);
    }

    [Fact]
    public void Should_Add_PaypalPayment_When_UnitOfWorkCommits()
    {
        // Arrange
        var user = new AppUser { Id = "paypal1", UserName = "PaypalUser" };
        var paypal = new Paypal
        {
            AppUserId = user.Id,
            PaypalEmail = "user@example.com",
            PaypalTransactionId = "TX1234567890",
            TransactionDate = DateTime.UtcNow
        };
        var currency = new Currency
        {
            CurrencyCode = "GBP",
            CurrencyName = "British Pound",
            CurrencySymbol = "£",
            MinorUnit = 2
        };

        _context.Users.Add(user);
        _context.PaymentMethods.Add(paypal);
        _context.Currencies.Add(currency);
        _context.SaveChanges();

        var payment = new Payment
        {
            PaymentMethodId = paypal.Id,
            PaymentMethod = paypal,
            Amount = 75.00m,
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
        Assert.Equal(paypal.Id, payments[0].PaymentMethodId);
        Assert.Equal("TX1234567890", ((Paypal)payments[0].PaymentMethod).PaypalTransactionId);
    }

    [Fact]
    public void Should_Not_Add_PaypalPayment_When_UnitOfWorkRollsBack()
    {
        // Arrange
        var user = new AppUser { Id = "paypal2", UserName = "RollbackPaypalUser" };
        var paypal = new Paypal
        {
            AppUserId = user.Id,
            PaypalEmail = "rollback@example.com",
            PaypalTransactionId = "TXROLLBACK123",
            TransactionDate = DateTime.UtcNow
        };
        var currency = new Currency
        {
            CurrencyCode = "USD",
            CurrencyName = "US Dollar",
            CurrencySymbol = "$",
            MinorUnit = 2
        };

        _context.Users.Add(user);
        _context.PaymentMethods.Add(paypal);
        _context.Currencies.Add(currency);
        _context.SaveChanges();

        var payment = new Payment
        {
            PaymentMethodId = paypal.Id,
            PaymentMethod = paypal,
            Amount = 120.00m,
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
