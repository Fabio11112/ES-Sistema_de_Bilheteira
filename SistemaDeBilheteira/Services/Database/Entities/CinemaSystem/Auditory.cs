using SistemaDeBilheteira.Services.Database.Entities.ProductSystem;

namespace SistemaDeBilheteira.Services.Database.Entities.CinemaSystem;

public class Auditory : DbItem
{
    public int Number { get; set; }
    public string Name { get; set; } = string.Empty;

    public Cinema? Cinema { get; set; }
    public Guid CinemaId { get; set; }
    
    public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    public ICollection<Function> Functions { get; set; } = new List<Function>();
}
