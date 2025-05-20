using SistemaDeBilheteira.Services.Database.Builders.CinemaSystemBuilder;
using SistemaDeBilheteira.Services.Database.Entities.ProductSystem;

namespace SistemaDeBilheteira.Services.UI;

public class SharedTicketBuilder (CinemaTicketBuilder builder)
{
    private CinemaTicketBuilder Builder { get; set; } = builder;

    public void WithFunctionId(Guid functionId)
    {
        Builder.WithFunction(functionId);
    }
    
    public void WithPrice(double price)
    {
        Builder.WithPrice(price);
    }
    
    public void WithMovieId(string? movieId)
    {
        Builder.WithMovieId(movieId);
    }
    
    public void WithSeatId(Guid seatId)
    {
        Builder.WithSeat(seatId);
    }

    public CinemaTicket? Build()
    {
        return Builder.Build();
    }
}