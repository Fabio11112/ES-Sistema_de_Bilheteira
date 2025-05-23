namespace SistemaDeBilheteira.Services.Database.Entities.PaymentSystem;
public class Currency
{
    public Guid Id { get; set; }
    public string CurrencyCode { get; set; }
    public string CurrencyName { get; set; }
    public string CurrencySymbol { get; set; }
    public int MinorUnit { get; set; }
    public ICollection<PaymentSystem.Payment> Payments { get; set; } = new List<PaymentSystem.Payment>();
}