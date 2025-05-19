using SistemaDeBilheteira.Services.Database.Entities.ProductSystem.PhysicalMedia;

namespace SistemaDeBilheteira.Services.Database.Builders;

public class MediaBuilder
{
    private double Price { get; set; }
    private string MovieId { get; set; }
    private Guid FormatId { get; set; }
    
    public MediaBuilder WithPrice(double price)
    {
        Price = price;
        return this;
    }

    public MediaBuilder WithMovieId(string movieId)
    {
        MovieId = movieId;
        return this;
    }

    public MediaBuilder WithFormatId(Guid formatId)
    {
        FormatId = formatId;
        return this;
    }
    
    public PhysicalMedia Build()
    {
        return new PhysicalMedia()
        {
            FormatId = FormatId,
            MovieId = MovieId,
            Price = Price,
        };
    }
}