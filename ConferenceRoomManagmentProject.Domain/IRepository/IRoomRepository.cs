using ConferenceRoomManagmentProject.Domain.Entities;
namespace ConferenceRoomManagmentProject.Domain.IRepository;

public interface IRoomRepository
{
    Room GetRoomById(int id);
    IEnumerable<Room> GetAvailableRooms(DateTime startTime, DateTime endTime, int capacity);
    void AddRoom(Room room);
    void UpdateRoom(Room room);
    void DeleteRoom(int id);
}