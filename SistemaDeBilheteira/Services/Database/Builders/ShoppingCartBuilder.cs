using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.Entities.ShoppingCart;

namespace SistemaDeBilheteira.Services.Database.Builders
{
    public class ShoppingCartItemBuilder 
    {
        public string AppUserId { get; set; } = null!;
        public Guid ProductId { get; set; }
        public int Quantity { get; set; } = 1;

        public ShoppingCartItemBuilder WithAppUserId(string appUserId)
        {
            AppUserId = appUserId;
            return this;
        }

        public ShoppingCartItemBuilder WithProductId(Guid productId)
        {
            ProductId = productId;
            return this;
        }

        public ShoppingCartItemBuilder WithQuantity(int quantity)
        {
            Quantity = quantity;
            return this;
        }

        public ShoppingCartItem? Build()
        {
            if (string.IsNullOrEmpty(AppUserId) || ProductId == Guid.Empty || Quantity <= 0)
            {
                return null;
            }

            var shoppingCartItem = new ShoppingCartItem
            {
                AppUserId = AppUserId,
                ProductId = ProductId,
                Quantity = Quantity
            };

            return shoppingCartItem;
        }
    }
}