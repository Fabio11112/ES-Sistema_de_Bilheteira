using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SistemaDeBilheteira.Services.Database.Context;



public class SistemaDeBilheteiraContextFactory : IDesignTimeDbContextFactory<SistemaDeBilheteiraContext>
{
    /**
        * This method is used to create a new instance of the DbContext with the specified options.
        * It is typically used by the EF Core tools when performing migrations or scaffolding.
        */
    public SistemaDeBilheteiraContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SistemaDeBilheteiraContext>();
        optionsBuilder.UseSqlite("Data Source=SistemaDeBilheteira.db");

        return new SistemaDeBilheteiraContext(optionsBuilder.Options);
    }
}
