using Microsoft.EntityFrameworkCore;
using ConferenceRoomManagmentProject.Domain.Entities;
using ConferenceRoomManagmentProject.Domain.IRepository;
using ConferenceRoomManagmentProject.Infrastructure.Persistence;

namespace ConferenceRoomManagmentProject.Infrastructure.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly AppDbContext _context;

    public RoomRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateTime startTime, DateTime endTime, int capacity)
    {
        var bookedRoomIds = await _context.Bookings
            .Where(b => b.StartTime < endTime && b.EndTime > startTime)
            .Select(b => b.RoomId)
            .ToListAsync();

        return await _context.Rooms
            .Where(r => r.Capacity >= capacity && !bookedRoomIds.Contains(r.Id))
            .ToListAsync();
    }



    public async Task<Room> AddRoomAsync(Room room)
    {
        await _context.Rooms.AddAsync(room);
        await _context.SaveChangesAsync();
        return room;
    }
    
    public async Task<Room> GetRoomByIdAsync(Guid id)
    {
        return await _context.Rooms.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task UpdateRoomAsync(Room room)
    {
        _context.Rooms.Update(room);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRoomAsync(Guid id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room != null)
        {
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<IEnumerable<Room>> GetAllRoomsAsync()
    {
        return await _context.Rooms.ToListAsync();
    }
}