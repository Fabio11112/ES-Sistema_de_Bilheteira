namespace SistemaDeBilheteira.Services.Database.Entities.Payment;

public class PaymentMethod : DbItem
{
    public required string AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;
    public bool IsDefault { get; set; } = false;
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}