using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.Entities.Payment;

namespace SistemaDeBilheteira.Services.Database.Context;

public class SistemaDeBilheteiraContext : IdentityDbContext<AppUser, AppRole, string>
{
    //Each set is a table from the Database
    public DbSet<Address> Addresses { get; set; }
    
    
    public SistemaDeBilheteiraContext()
    {
    }

    public SistemaDeBilheteiraContext(DbContextOptions<SistemaDeBilheteiraContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=SistemaDeBilheteira.db");
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCart { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }


    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Paypal> Paypals { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Currency> Currencies { get; set; }



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


        // Herança TPH para PaymentMethod
        modelBuilder.Entity<PaymentMethod>()
            .HasDiscriminator<string>("PaymentMethodType")
            .HasValue<Card>("Card")  
            .HasValue<Paypal>("Paypal");

        // Relação 1:N PaymentMethod -> Payments
        modelBuilder.Entity<PaymentMethod>()
            .HasMany(pm => pm.Payments)
            .WithOne(p => p.PaymentMethod)
            .HasForeignKey(p => p.PaymentMethodId);

        // Relação 1:N Currency -> Payments
        modelBuilder.Entity<Currency>()
            .HasMany(c => c.Payments)
            .WithOne(p => p.Currency)
            .HasForeignKey(p => p.CurrencyId);
        }


}
