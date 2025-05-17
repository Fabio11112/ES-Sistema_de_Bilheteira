namespace SistemaDeBilheteira.Services.Database.Entities.Payment;

public class PurchaseItem : DbItem
{
    public Purchase Purchase { get; set; }
    public Guid PurchaseId { get; set; }
    public Product Product { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    
    //public double priceAtTime
}   