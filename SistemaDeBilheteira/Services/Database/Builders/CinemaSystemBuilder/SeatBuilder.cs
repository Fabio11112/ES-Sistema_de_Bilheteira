using SistemaDeBilheteira.Services.Database.Entities.ProductSystem;

namespace SistemaDeBilheteira.Services.Database.Builders.CinemaSystemBuilder;

public class SeatBuilder
{
    public int Number { get; set; }
    public string Letter { get; set; } = string.Empty;
    public Guid AuditoryId { get; set; }

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