using Microsoft.EntityFrameworkCore;
using ConferenceRoomManagmentProject.Domain.Entities;

namespace ConferenceRoomManagmentProject.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<BookingService> BookingServices { get; set; }
    public DbSet<RoomService> RoomServices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Ensure all GUIDs are set as Primary Keys
        modelBuilder.Entity<Room>().HasKey(r => r.Id);
        modelBuilder.Entity<Booking>().HasKey(b => b.Id);
        modelBuilder.Entity<Service>().HasKey(s => s.Id);
        modelBuilder.Entity<BookingService>().HasKey(bs => bs.Id);
        modelBuilder.Entity<RoomService>().HasKey(rs => rs.Id);
        
        modelBuilder.Entity<Room>()
            .Property(r => r.BaseHourlyRate)
            .HasColumnType("decimal(18,2)"); // Adjust precision and scale as needed

        modelBuilder.Entity<Booking>()
            .Property(b => b.TotalPrice)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<BookingService>()
            .Property(bs => bs.Price)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Service>()
            .Property(s => s.Price)
            .HasColumnType("decimal(18,2)");
        
        modelBuilder.Entity<Room>()
            .HasMany(r => r.Services)
            .WithOne(s => s.Room)
            .HasForeignKey(s => s.RoomId)
            .OnDelete(DeleteBehavior.Cascade); // Enables cascade delete

        // Configure Room -> Booking relationship with Cascade Delete
        modelBuilder.Entity<Room>()
            .HasMany(r => r.Bookings)
            .WithOne(b => b.Room)
            .HasForeignKey(b => b.RoomId)
            .OnDelete(DeleteBehavior.Cascade); // Enables cascade delete
        
        base.OnModelCreating(modelBuilder);
    }
    /*
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Service> Services { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Additional configurations if necessary
    }
    */
}
