namespace SistemaDeBilheteira.Services.Database.Entities.Payment;
public class Currency
{
    public Guid Id { get; set; }
    public string CurrencyCode { get; set; }
    public string CurrencyName { get; set; }
    public string CurrencySymbol { get; set; }
    public int MinorUnit { get; set; }
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}