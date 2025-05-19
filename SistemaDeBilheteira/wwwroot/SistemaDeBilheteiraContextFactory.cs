using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SistemaDeBilheteira.Services.Database.Context;

public class SistemaDeBilheteiraContextFactory : IDesignTimeDbContextFactory<SistemaDeBilheteiraContext>
{
    public SistemaDeBilheteiraContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SistemaDeBilheteiraContext>();
        optionsBuilder.UseSqlite("Data Source=SistemaDeBilheteira.db");

        return new SistemaDeBilheteiraContext(optionsBuilder.Options);
    }
}
