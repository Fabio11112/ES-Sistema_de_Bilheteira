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

}

