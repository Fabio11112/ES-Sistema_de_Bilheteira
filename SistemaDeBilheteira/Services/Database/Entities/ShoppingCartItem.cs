
namespace SistemaDeBilheteira.Services.Database.Entities;

public class ShoppingCartItem : IDbItem
{
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    // Payload
    public int Quantity { get; set; }
    public DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime UpdatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
