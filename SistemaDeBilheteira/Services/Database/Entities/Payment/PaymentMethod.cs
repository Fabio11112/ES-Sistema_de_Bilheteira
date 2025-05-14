namespace SistemaDeBilheteira.Services.Database.Entities.Payment;

public abstract class PaymentMethod : DbItem
{
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;
    public bool IsDefault { get; set; } = false;
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public int balance { get; set; } = 500;
}