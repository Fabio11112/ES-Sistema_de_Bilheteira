using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.Entities.ProductSystem;

namespace SistemaDeBilheteira.Services.Database.Builders;

public class CinemaTicketBuilder
{
    private Guid SeatId { get; set; }
    public Guid FunctionId { get; set; }

    public CinemaTicketBuilder WithSeatId(Guid seatId)
    {
        SeatId = seatId;
        return this;
    }

    public CinemaTicketBuilder WithFunctionId(Guid functionId)
    {
        FunctionId = functionId;
        return this;
    }

    public CinemaTicket Build()
    {
        return new CinemaTicket
        {
            SeatId = SeatId,
            FunctionId = FunctionId
        };
    }
}




