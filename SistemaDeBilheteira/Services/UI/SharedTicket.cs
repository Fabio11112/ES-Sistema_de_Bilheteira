namespace SistemaDeBilheteira.Services.UI;

using SistemaDeBilheteira.Services.Database.Builders.CinemaSystemBuilder;


public class SharedTicket
{
    public CinemaTicketBuilder? CinemaTicket { get; set; } = new CinemaTicketBuilder();
    public int Quantity { get; set; } = 1;

    public void Reset()
    {
        Quantity = 1;
    }
}