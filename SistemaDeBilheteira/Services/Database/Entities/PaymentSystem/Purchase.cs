namespace SistemaDeBilheteira.Services.Database.Entities.PaymentSystem;

public class Purchase : DbItem
{
    public AppUser AppUser { get; set; }
    public string AppUserId { get; set; }
    public double Amount { get; set; }
    public Address? Address { get; set; }
    public ICollection<PurchaseItem> PurchaseItems { get; set; }
    
}   