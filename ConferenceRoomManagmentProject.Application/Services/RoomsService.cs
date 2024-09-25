using ConferenceRoomManagmentProject.Application.DTO;
using ConferenceRoomManagmentProject.Application.Interfaces;
using ConferenceRoomManagmentProject.Domain.Entities;
using ConferenceRoomManagmentProject.Domain.IRepository;
namespace ConferenceRoomManagmentProject.Application.Services;

public class RoomsService : IRoomsService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IBookingRepository _bookingRepository;

    public RoomsService(IRoomRepository roomRepository, IBookingRepository bookingRepository)
    {
        _roomRepository = roomRepository;
        _bookingRepository = bookingRepository;
    }

    public async Task<RoomDTO> AddRoomAsync(RoomDTO roomDto)
    {
        if (roomDto == null)
        {
            throw new ArgumentNullException(nameof(roomDto), "Room data cannot be null");
        }

        var room = new Room
        {
            Id = Guid.NewGuid(),
            Name = roomDto.Name,
            Capacity = roomDto.Capacity,
            BaseHourlyRate = roomDto.BasePricePerHour,
            Services = roomDto.Services.Select(s => new Service { Name = s.Name, Price = s.Price }).ToList()
        };

        try
        {
            await _roomRepository.AddRoomAsync(room);
            return roomDto;
        }
        catch (Exception ex)
        {
            // Log exception if necessary
            throw new Exception("Failed to add room: " + ex.Message, ex);
        }
    }

    // public Task UpdateRoomAsync(Guid roomId, RoomUpdateDTO roomUpdateDto)
    // {
    //     throw new NotImplementedException();
    // }

    public async Task<RoomDTO> UpdateRoomAsync(Guid roomId, RoomDTO roomDto)
    {
        var room = await _roomRepository.GetRoomByIdAsync(roomId);
        if (room == null)
        {
            throw new KeyNotFoundException("Room not found");
        }

        room.Name = roomDto.Name;
        room.Capacity = roomDto.Capacity;
        room.BaseHourlyRate = roomDto.BasePricePerHour;
        room.Services = roomDto.Services.Select(s => new Service { Name = s.Name, Price = s.Price }).ToList();

        try
        {
            await _roomRepository.UpdateRoomAsync(room);
            return roomDto;
        }
        catch (Exception ex)
        {
            // Log exception if necessary
            throw new Exception("Failed to update room: " + ex.Message, ex);
        }
    }

    public async Task DeleteRoomAsync(Guid roomId)
    {
        var room = await _roomRepository.GetRoomByIdAsync(roomId);
        if (room == null)
        {
            throw new KeyNotFoundException("Room not found");
        }

        try
        {
            await _roomRepository.DeleteRoomAsync(roomId);
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to delete room: " + ex.Message, ex);
        }
    }

    public async Task<List<RoomDTO>> GetAvailableRoomsAsync(DateTime date, DateTime startTime, DateTime endTime, int capacity)
    {
        if (startTime >= endTime)
        {
            throw new ArgumentException("Start time must be earlier than end time.");
        }

        var rooms = await _roomRepository.GetAllRoomsAsync();
        var bookings = await _bookingRepository.GetAllBookingsForTimeAsync(date, startTime, endTime);
        // Filter rooms based on capacity and availability
        
        var availableRooms = rooms
            .Where(r => r.Capacity >= capacity) // Check if the room meets the capacity requirement
            .Where(r => bookings.All(b => b.RoomId != r.Id)) // Check if there are no overlapping bookings
            .Select(r => new RoomDTO
            {
                Name = r.Name,
                Capacity = r.Capacity,
                BasePricePerHour = r.BaseHourlyRate,
                Services = r.Services.Select(s => new ServiceDTO { Name = s.Name, Price = s.Price }).ToList()
            })
            .ToList();

        
        return availableRooms;
    }
    
}
