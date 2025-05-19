namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem;

public class Auditory : DbItem
{
    public int Number { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    public ICollection<Function> Functions { get; set; } = new List<Function>();
}
