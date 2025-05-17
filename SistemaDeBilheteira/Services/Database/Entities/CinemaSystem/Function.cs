namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem;

public class Function : DbItem
{
    public DateTime Date { get; set; }
    public double Price { get; set; }
    public Guid CinemaId { get; set; }
    public Cinema Cinema { get; set; } = null!;

    public Guid AuditoryId { get; set; }
    public Auditory Auditory { get; set; }

    public ICollection<CinemaTicket> Tickets { get; set; } = new List<CinemaTicket>();
}
