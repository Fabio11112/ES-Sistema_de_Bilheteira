using System;
using SistemaDeBilheteira.Services.Database.Entities.PaymentSystem;

namespace SistemaDeBilheteira.Services.Database.Builders
{
    public class CardBuilder : PaymentMethodBuilder
    {
        private readonly Card _card = new Card();

        public CardBuilder WithNameOnCard(string name)
        {
            _card.CardHolderName = name;
            return this;
        }

        public CardBuilder WithCardNumber(string number)
        {
            _card.CardNumber = number;
            return this;
        }

        public CardBuilder WithCvv(string cvv)
        {
            _card.Cvv = cvv;
            return this;
        }

        public CardBuilder WithExpirationDate(DateTime expirationDate)
        {
            _card.ExpirationDate = expirationDate;
            return this;
        }

        // public CardBuilder WithBrand(string brand)
        // {
        //     _card.Brand = brand;
        //     return this;
        // }

        public Card Build()
        {
            SemiBuild(_card);
            
            if (string.IsNullOrEmpty(_card.CardNumber))
                throw new InvalidOperationException("Card number is required.");

            return _card;
        }

        
    }
}