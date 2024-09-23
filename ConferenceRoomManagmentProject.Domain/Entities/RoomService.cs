using ConferenceRoomManagmentProject.Domain.IEntities;

namespace ConferenceRoomManagmentProject.Domain.Entities;

public class RoomService : EntityBase, IRoomService
{
    public Guid  RoomId { get; set; }
    public Room? Room { get; set; }
    public Guid  ServiceId { get; set; }
    public Service? Service { get; set; }
}