using ConferenceRoomManagmentProject.Application.DTO;

namespace ConferenceRoomManagmentProject.Application.Interfaces;

public interface IRoomsService
{
    Task<RoomDTO> AddRoomAsync(RoomDTO roomDto);
    Task<RoomDTO> UpdateRoomAsync(Guid roomId, RoomDTO roomDto);
    Task DeleteRoomAsync(Guid roomId);
    Task<List<RoomDTO>> GetAvailableRoomsAsync(DateTime date, DateTime startTime, DateTime endTime, int capacity);
}
