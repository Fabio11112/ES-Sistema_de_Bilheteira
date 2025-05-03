using SistemaDeBilheteira.Services.Database.Entities.Payment;

namespace SistemaDeBilheteira.Services.Database.Entities.CardServices
{
    public interface ICardServices
    {
        Task<Card> AddCardAsync(Card card, string userId);
        Task<List<Card>> GetUserCardsAsync(string userId);
        Task SetDefaultCardAsync(Guid cardId, string userId);
        Task DeleteCardAsync(Guid cardId, string userId);
    }
}
