using ConferenceRoomManagmentProject.Domain.Entities;

namespace ConferenceRoomManagmentProject.Domain.IEntities;

public interface IRoomService
{
    Guid  RoomId { get; set; }
    Guid  ServiceId { get; set; }
    Room Room { get; set; }
    Service Service { get; set; }
}