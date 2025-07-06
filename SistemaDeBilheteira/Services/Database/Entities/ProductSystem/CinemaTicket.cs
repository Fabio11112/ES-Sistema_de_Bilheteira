namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem;

public class CinemaTicket : Product
{

    public Guid FunctionId { get; set; }
    public Function Function { get; set; } = null!;
    public Seat Seat { get; set; } = null!;
    public Guid SeatId { get; set; }
    
    public override string GetProductType()
    {
        return "Cinema Ticket";
    }

    public override string PrintDetails()
    {
        return $"Cinema Ticket for Seat {Seat.Number}{Seat.Letter} in {Function.Date:dd/MM/yyyy}" +
               $" | {Function.Auditory.Name}";
    }

}

