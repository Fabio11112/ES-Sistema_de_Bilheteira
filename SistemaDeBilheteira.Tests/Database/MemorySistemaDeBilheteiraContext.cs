using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SistemaDeBilheteira.Services.Database.Context;

namespace SistemaDeBilheteira.Tests.Database;

public class MemorySistemaDeBilheteiraContext : SistemaDeBilheteiraContext
{
    public MemorySistemaDeBilheteiraContext(DbContextOptions<SistemaDeBilheteiraContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
        
        options.UseSqlite(connection);
    }
}