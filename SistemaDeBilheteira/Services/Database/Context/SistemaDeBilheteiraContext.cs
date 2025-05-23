using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaDeBilheteira.Services.Database.Entities;
using SistemaDeBilheteira.Services.Database.Entities.CinemaSystem;
using SistemaDeBilheteira.Services.Database.Entities.PaymentSystem;
using SistemaDeBilheteira.Services.Database.Entities.ProductSystem.Rental;
using SistemaDeBilheteira.Services.Database.Entities.ProductSystem;
using SistemaDeBilheteira.Services.Database.Entities.ProductSystem.PhysicalMedia;
using SistemaDeBilheteira.Services.Database.Entities.ShoppingCart;

namespace SistemaDeBilheteira.Services.Database.Context;

public class SistemaDeBilheteiraContext : IdentityDbContext<AppUser, AppRole, string>
{
    //Each set is a table from the Database
    public DbSet<Address> Addresses { get; set; }

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
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<PurchaseItem> PurchaseItems { get; set; }
    public DbSet<PhysicalMediaFormat> PhysicalMediaFormats { get; set; }
    public DbSet<Function> Functions { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Auditory> Auditories { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<CinemaTicket> CinemaTickets { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Product>().UseTpcMappingStrategy();
        modelBuilder.Entity<Rental>().ToTable("Rentals");
        modelBuilder.Entity<PhysicalMedia>().ToTable("PhysicalMedias");

        modelBuilder.Entity<CinemaTicket>().ToTable("CinemaTickets");
        
        modelBuilder.Entity<Product>()
            .Property(p => p.Id)
            .ValueGeneratedNever();


        modelBuilder.Entity<ShoppingCartItem>()
            .HasKey(sci => new { sci.AppUserId, sci.ProductId });

        modelBuilder.Entity<PurchaseItem>()
            .HasKey(sci => new { sci.PurchaseId, sci.ProductId });

        modelBuilder.Entity<ShoppingCartItem>()
            .HasOne(sci => sci.AppUser)
            .WithMany(u => u.ShoppingCartItems)
            .HasForeignKey(sci => sci.AppUserId);

        modelBuilder.Entity<ShoppingCartItem>()
            .HasOne(sci => sci.Product)
            .WithMany(p => p.ShoppingCartItems)
            .HasForeignKey(sci => sci.ProductId);

        
        modelBuilder.Entity<PaymentMethod>().UseTpcMappingStrategy();
        modelBuilder.Entity<PaymentMethod>()
            .Property(p => p.Id)
            .ValueGeneratedNever();

        var paymentMethodTypes = new[] { typeof(Card), typeof(Paypal) };

        foreach (var type in paymentMethodTypes)
        {
            modelBuilder.Entity(type)
                .Property(nameof(DbItem.Id))
                .ValueGeneratedNever();
        }

        modelBuilder.Entity<Card>().ToTable("Cards");



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


        // Relação 1:N Purchase -> PurchaseItems
        modelBuilder.Entity<Function>()
            .HasOne(f => f.Auditory)
            .WithMany(a => a.Functions)
            .HasForeignKey(f => f.AuditoryId);
    }


}
