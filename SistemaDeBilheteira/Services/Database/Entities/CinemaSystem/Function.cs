namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem;

public class Function : DbItem
{
    public DateTime Date { get; set; }
    public Guid AuditoryId { get; set; }
    public Auditory Auditory { get; set; }
    //public ICollection<CinemaTicket> Tickets { get; set; } = new List<CinemaTicket>();
}
