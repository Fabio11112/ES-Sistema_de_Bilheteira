using SistemaDeBilheteira.Services.Database.Entities.CinemaSystem;

namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem;

public class Function : DbItem
{
    public DateTime Date { get; set; }
    public Guid AuditoryId { get; set; }
    public Auditory Auditory { get; set; }
}
