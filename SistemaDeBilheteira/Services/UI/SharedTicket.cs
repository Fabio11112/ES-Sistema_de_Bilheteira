namespace SistemaDeBilheteira.Services.UI;

using SistemaDeBilheteira.Services.Database.Builders.CinemaSystemBuilder;

/*
    * SharedTicket.cs
    * 
    * This class is used to manage the shared ticket information in the application.
    * It contains properties for the cinema ticket and the quantity of tickets.
    *
*/
public class SharedTicket
{
    public CinemaTicketBuilder? CinemaTicket { get; set; } = new CinemaTicketBuilder();
    public int Quantity { get; set; } = 1;

    public void Reset()
    {
        Quantity = 1;
    }
}