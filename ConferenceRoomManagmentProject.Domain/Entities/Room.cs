using ConferenceRoomManagmentProject.Domain.IEntities;

namespace ConferenceRoomManagmentProject.Domain.Entities;

public class Room : EntityBase, IRoom
{
    public string Name { get; set; }
    public int? Capacity { get; set; }
    public decimal? BaseHourlyRate { get; set; }
    public ICollection<Service> Services { get; set; }
    
    public Room()
    {
        Services = new List<Service>();
    }
}