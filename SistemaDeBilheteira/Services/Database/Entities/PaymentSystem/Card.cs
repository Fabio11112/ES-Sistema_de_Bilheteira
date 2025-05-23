namespace SistemaDeBilheteira.Services.Database.Entities.PaymentSystem;
public class Card : PaymentMethod
{
    public string CardHolderName { get; set; }
    public string CardNumber { get; set; }
    public String Cvv { get; set; }
    public DateTime ExpirationDate { get; set; }
    public override string PrintInformation()
    {
        return $"{CardHolderName} - **** **** **** {CardNumber[^4..]}";
    }
}