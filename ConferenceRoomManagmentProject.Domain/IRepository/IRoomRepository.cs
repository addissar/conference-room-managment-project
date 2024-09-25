using ConferenceRoomManagmentProject.Domain.Entities;
namespace ConferenceRoomManagmentProject.Domain.IRepository;

public interface IRoomRepository
{
    Task<Room> GetRoomByIdAsync(Guid id);
    Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateTime startTime, DateTime endTime, int capacity);
    Task<Room> AddRoomAsync(Room room);
    Task UpdateRoomAsync(Room room);
    Task DeleteRoomAsync(Guid id);

    Task<IEnumerable<Room>> GetAllRoomsAsync();
}