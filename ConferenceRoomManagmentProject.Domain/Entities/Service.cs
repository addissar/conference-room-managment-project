using ConferenceRoomManagmentProject.Domain.IEntities;

namespace ConferenceRoomManagmentProject.Domain.Entities;

public class Service : EntityBase, IService
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
}