using SistemaDeBilheteira.Services.Database.Entities.CinemaSystem;

namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem;

public class Seat : DbItem
{
    public int Number { get; set; }
    public string Letter { get; set; } = string.Empty;

    public Guid AuditoryId { get; set; }
    public Auditory Auditory { get; set; } = null!;
}
