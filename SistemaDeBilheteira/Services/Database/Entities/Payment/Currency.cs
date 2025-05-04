namespace SistemaDeBilheteira.Services.Database.Entities.Payment;
public class Currency
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public int MinorUnit { get; set; }
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}