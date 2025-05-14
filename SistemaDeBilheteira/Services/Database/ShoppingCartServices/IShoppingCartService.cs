using System.Collections.Generic;
using SistemaDeBilheteira.Services.Database.Entities;

public interface IShoppingCartService
{
    void AddItemToCart(string userId, Guid productId, int quantity = 1);
    void RemoveItemFromCart(string userId, Guid productId);
    List<ShoppingCartItem> GetCartItems(string userId);
    void ClearCart(string userId);
    void UpdateItemQuantity(string userId, Guid productId, int newQuantity);
    void AddTestCartItem();
}
