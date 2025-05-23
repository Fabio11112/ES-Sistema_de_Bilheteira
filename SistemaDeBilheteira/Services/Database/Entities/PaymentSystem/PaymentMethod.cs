using SistemaDeBilheteira.Services.Database.Entities.User;

namespace SistemaDeBilheteira.Services.Database.Entities.PaymentSystem;

public abstract class PaymentMethod : DbItem
{
    public string? AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;
    public bool IsDefault { get; set; }
    public double Balance { get; set; } = 500;

    public abstract string PrintInformation();
}