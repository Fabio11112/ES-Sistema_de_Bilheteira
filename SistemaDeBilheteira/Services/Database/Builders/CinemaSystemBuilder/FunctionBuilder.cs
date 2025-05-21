using SistemaDeBilheteira.Services.Database.Entities.ProductSystem;

namespace SistemaDeBilheteira.Services.Database.Builders.CinemaSystemBuilder;

public class FunctionBuilder
{
    private DateTime Date { get; set; }
    private Guid AuditoryId { get; set; }

    public FunctionBuilder WithDate(DateTime date)
    {
        Date = date;
        return this;
    }

    public FunctionBuilder WithAuditory(Guid auditoryId)
    {
        AuditoryId = auditoryId;
        return this;
    }

    public Function Build()
    {
        return new Function()
        {
            Date = Date,
            AuditoryId = AuditoryId,
        };
    }
}