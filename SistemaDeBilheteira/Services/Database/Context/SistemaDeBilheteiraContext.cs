using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaDeBilheteira.Services.Database.Entities;

namespace SistemaDeBilheteira.Services.Database.Context;

public class SistemaDeBilheteiraContext : IdentityDbContext<AppUser, AppRole, int>
{
    //Each set is a table from the Database
    public DbSet<Address> Addresses { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    public SistemaDeBilheteiraContext()
    {
    }

    public SistemaDeBilheteiraContext(DbContextOptions<SistemaDeBilheteiraContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCart { get; set; }

    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ShoppingCartItem>()
            .HasKey(sci => new { sci.AppUserId, sci.ProductId });

        modelBuilder.Entity<ShoppingCartItem>()
            .HasOne(sci => sci.AppUser)
            .WithMany(u => u.ShoppingCartItems)
            .HasForeignKey(sci => sci.AppUserId);

        modelBuilder.Entity<ShoppingCartItem>()
            .HasOne(sci => sci.Product)
            .WithMany(p => p.ShoppingCartItems)
            .HasForeignKey(sci => sci.ProductId);
    }

}
