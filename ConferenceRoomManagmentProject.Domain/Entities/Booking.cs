using ConferenceRoomManagmentProject.Domain.IEntities;

namespace ConferenceRoomManagmentProject.Domain.Entities;

public class Booking : EntityBase, IBooking
{
    public Guid  RoomId { get; set; }
    
    public DateTime Date { get; set; }
    
    public Room Room { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ICollection<Service> Services { get; set; }
    public decimal TotalPrice { get; set; }

    public Booking()
    {
        Services = new List<Service>();
    }
}