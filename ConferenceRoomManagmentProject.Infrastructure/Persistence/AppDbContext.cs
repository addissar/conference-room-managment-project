using Microsoft.EntityFrameworkCore;
using ConferenceRoomManagmentProject.Domain.Entities;

namespace ConferenceRoomManagmentProject.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
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
}
