using SistemaDeBilheteira.Services.Database.Entities.ProductSystem;

namespace SistemaDeBilheteira.Services.Database.Builders.CinemaSystemBuilder;

public class CinemaTicketBuilder
{
    private Guid _functionId = Guid.Empty;
    private Guid _seatId = Guid.Empty;
    private double _price;
    private string? _movieId;

    public CinemaTicketBuilder WithPrice(double price)
    {
        _price = price;
        return this;
    }

    public CinemaTicketBuilder WithMovieId(string? movieId)
    {
        _movieId = movieId;
        return this;
    }
    public CinemaTicketBuilder WithFunction(Guid functionId)
    {
        _functionId = functionId;
        return this;
    }
    public CinemaTicketBuilder WithSeat(Guid seatId)
    {
        _seatId = seatId;
        return this;
    }

    public CinemaTicket? Build()
    {
        if (IsSomethingNotSet())
            return null;

        return new CinemaTicket()
        {
            FunctionId = _functionId,
            SeatId = _seatId,
        };
    }

    private bool IsSomethingNotSet()
    {
        return _functionId == Guid.Empty || _seatId == Guid.Empty || _movieId == null || _price == 0;
    }
}