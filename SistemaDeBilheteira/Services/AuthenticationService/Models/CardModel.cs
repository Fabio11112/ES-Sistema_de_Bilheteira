namespace SistemaDeBilheteira.Services.AuthenticationService.Models;
public class CardModel : IModel
    {
        public string NameOnCard { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string CVV { get; set; } = string.Empty;
        public DateTime? ExpDate { get; set; }
    }