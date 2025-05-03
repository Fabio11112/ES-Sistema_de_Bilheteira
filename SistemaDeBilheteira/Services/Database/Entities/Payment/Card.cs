namespace SistemaDeBilheteira.Services.Database.Entities.Payment;

public class Card : PaymentMethod
{
    public string CardNumber { get; set; } = string.Empty;
    public string CardHolderName { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public string Cvv { get; set; } = string.Empty;
}