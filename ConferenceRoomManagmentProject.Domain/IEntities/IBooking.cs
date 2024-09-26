using ConferenceRoomManagmentProject.Domain.Entities;

namespace ConferenceRoomManagmentProject.Domain.IEntities;

public interface IBooking
{
    Guid  RoomId { get; set; }
    DateTime Date { get; set; }
    DateTime StartTime { get; set; }
    DateTime EndTime { get; set; }
    ICollection<Service> Services { get; set; }
    decimal TotalPrice { get; set; }
}