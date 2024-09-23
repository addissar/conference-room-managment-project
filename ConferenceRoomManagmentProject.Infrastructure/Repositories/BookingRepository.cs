using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    public Task UpdateBookingAsync(Booking booking)
    {
        throw new NotImplementedException();
    }

    public async Task<Booking> GetBookingByIdAsync(Guid id)
    {
        return await _context.Bookings.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task<IEnumerable<Booking>> GetBookingsForRoomAsync(Guid roomId,DateTime startTime, DateTime endTime)
    {
        //add date
        return await _context.Bookings
            .Where(b => b.RoomId == roomId)
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