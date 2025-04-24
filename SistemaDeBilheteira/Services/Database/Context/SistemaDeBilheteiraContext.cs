using Microsoft.EntityFrameworkCore;
using SistemaDeBilheteira.Services.Database.Entities;

namespace SistemaDeBilheteira.Services.Database.Context;


public class SistemaDeBilheteiraContext: DbContext
{
    //Each set is a table from the Database
    public DbSet<User> Users { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=SistemaDeBilheteira.db");
    }
}