namespace SistemaDeBilheteira.Services.Database.Entities.Payment;

public class Purchase : DbItem
{
    public AppUser AppUser { get; set; }
    public string AppUserId { get; set; }
    public double Amount { get; set; }
    
}