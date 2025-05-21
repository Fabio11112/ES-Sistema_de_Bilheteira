using SistemaDeBilheteira.Services.Database.Entities.CinemaSystem;

namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem;

public class Cinema : DbItem
{
    public string Name { get; set; } = string.Empty;

    public ICollection<Auditory> Auditoriums { get; set; } = new List<Auditory>();
}
