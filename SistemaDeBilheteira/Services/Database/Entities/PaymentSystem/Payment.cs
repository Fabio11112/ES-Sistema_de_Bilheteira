namespace SistemaDeBilheteira.Services.Database.Entities.PaymentSystem;

public class Payment : DbItem 
{
    public Guid PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; } = null!;
    public decimal Amount { get; set; }

    public Guid CurrencyId { get; set; }
    public Currency Currency { get; set; } = null!;

}