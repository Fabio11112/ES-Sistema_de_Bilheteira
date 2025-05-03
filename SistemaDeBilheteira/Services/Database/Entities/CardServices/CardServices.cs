using Microsoft.EntityFrameworkCore;
using SistemaDeBilheteira.Services.Database.Context;
using SistemaDeBilheteira.Services.Database.Entities.Payment;
using System.Security.Claims;

namespace SistemaDeBilheteira.Services.Database.Entities.CardServices;

    
    public class CardServices : ICardServices
    {
        private readonly SistemaDeBilheteiraContext _context;
        private readonly ILogger<CardServices> _logger;

        public CardServices(
            SistemaDeBilheteiraContext context,
            ILogger<CardServices> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Card> AddCardAsync(Card card, string userId)
        {
            try
            {
                // Basic validation
                if (string.IsNullOrWhiteSpace(userId))
                    throw new ArgumentException("User ID cannot be empty");

                if (card == null)
                    throw new ArgumentNullException(nameof(card));

                // Set card properties
                card.AppUserId = userId;
                card.CreatedAt = DateTime.UtcNow;
                card.UpdatedAt = DateTime.UtcNow;

                // If this is the first card, set as default
                card.IsDefault = !await _context.Cards.AnyAsync(c => c.AppUserId == userId);

                // Add to database
                _context.Cards.Add(card);
                await _context.SaveChangesAsync();

                return card;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding card for user {UserId}", userId);
                throw;
            }
        }

        public async Task<List<Card>> GetUserCardsAsync(string userId)
        {
            return await _context.Cards
                .Where(c => c.AppUserId == userId)
                .OrderByDescending(c => c.IsDefault)
                .ThenByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        public async Task SetDefaultCardAsync(Guid cardId, string userId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            
            try
            {
                // Reset all cards to non-default first
                await _context.Cards
                    .Where(c => c.AppUserId == userId)
                    .ExecuteUpdateAsync(setters => 
                        setters.SetProperty(c => c.IsDefault, false));

                // Set the selected card as default
                var affectedRows = await _context.Cards
                    .Where(c => c.Id == cardId && c.AppUserId == userId)
                    .ExecuteUpdateAsync(setters => 
                        setters.SetProperty(c => c.IsDefault, true));

                if (affectedRows == 0)
                    throw new InvalidOperationException("Card not found or doesn't belong to user");

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task DeleteCardAsync(Guid cardId, string userId)
        {
            var card = await _context.Cards
                .FirstOrDefaultAsync(c => c.Id == cardId && c.AppUserId == userId);

            if (card == null)
                throw new KeyNotFoundException("Card not found or doesn't belong to user");

            if (card.IsDefault)
            {
                // Find another card to set as default
                var newDefaultCard = await _context.Cards
                    .Where(c => c.AppUserId == userId && c.Id != cardId)
                    .OrderByDescending(c => c.CreatedAt)
                    .FirstOrDefaultAsync();

                if (newDefaultCard != null)
                {
                    newDefaultCard.IsDefault = true;
                }
            }

            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
        }

        // Helper method to mask card number for display
        public static string GetMaskedCardNumber(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber) || cardNumber.Length < 4)
                return string.Empty;

            return $"•••• •••• •••• {cardNumber[^4..]}";
        }
    }