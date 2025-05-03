namespace SistemaDeBilheteira.Services.Database.Entities.Payment;

public class Currency : DbItem
{
    public Guid CurrencyId { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
    public string CurrencyName { get; set; } = string.Empty;
    public required string CurrencySymbol { get; set; }
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public int MinorUnit { get; set; } = 2;
}