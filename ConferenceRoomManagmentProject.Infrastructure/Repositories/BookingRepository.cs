using Microsoft.EntityFrameworkCore;
using ConferenceRoomManagmentProject.Domain.Entities;
using ConferenceRoomManagmentProject.Domain.IRepository;
using ConferenceRoomManagmentProject.Infrastructure.Persistence;

namespace ConferenceRoomManagmentProject.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _context;

    public BookingRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Booking> AddBookingAsync(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
        return booking;
    }

    public async Task UpdateBookingAsync(Booking booking)
    {
        _context.Bookings.Update(booking);
        await _context.SaveChangesAsync();
    }


    public async Task<Booking> GetBookingByIdAsync(Guid id)
    {
        return await _context.Bookings.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task<IEnumerable<Booking>> GetBookingsForRoomAsync(Guid roomId, DateTime date, DateTime startTime, DateTime endTime)
    {
        return await _context.Bookings
            .Where(b => b.RoomId == roomId && b.StartTime < endTime && b.EndTime > startTime && b.Date == date)
            .ToListAsync();
    }

    public async Task<IEnumerable<Booking>> GetAllBookingsForTimeAsync(DateTime date, DateTime startTime, DateTime endTime)
    {
        if (startTime >= endTime)
        {
            throw new ArgumentException("Start time must be earlier than end time.");
        }

        return await _context.Bookings
            .Where(b => b.Date == date && b.StartTime < endTime && b.EndTime > startTime)
            .ToListAsync();
    }

    public async Task DeleteBookingAsync(Guid id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking != null)
        {
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
    }
}