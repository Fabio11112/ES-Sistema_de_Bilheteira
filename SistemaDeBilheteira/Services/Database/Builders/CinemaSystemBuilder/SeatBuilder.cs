using SistemaDeBilheteira.Services.Database.Entities.ProductSystem;

namespace SistemaDeBilheteira.Services.Database.Builders.CinemaSystemBuilder;

public class SeatBuilder
{
    private int Number { get; set; }
    private string Letter { get; set; } = string.Empty;
    private Guid AuditoryId { get; set; }

    public SeatBuilder WithNumber(int number)
    {
        Number = number;
        return this;
    }

    public SeatBuilder WithLetter(string letter)
    {
        Letter = letter;
        return this;
    }

    public SeatBuilder WithAuditory(Guid auditoryId)
    {
        AuditoryId = auditoryId;
        return this;
    }

    public Seat Build()
    {
        return new Seat()
        {
            Number = Number,
            Letter = Letter,
            AuditoryId = AuditoryId,
        };
    }
}