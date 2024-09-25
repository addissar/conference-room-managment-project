using ConferenceRoomManagmentProject.Domain.IEntities;

namespace ConferenceRoomManagmentProject.Domain.Entities;

public class Service : EntityBase, IService
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
    
    // Foreign key to Room
    public Guid RoomId { get; set; }

    // Navigation Property to Room
    public Room Room { get; set; }
}