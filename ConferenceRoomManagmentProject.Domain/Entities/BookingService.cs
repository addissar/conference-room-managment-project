using ConferenceRoomManagmentProject.Domain.IEntities;

namespace ConferenceRoomManagmentProject.Domain.Entities;

public class BookingService : EntityBase, IBookingService
{
    public Guid  BookingId { get; set; }
    public Booking? Booking { get; set; }
    public Guid  ServiceId { get; set; }
    public Service? Service { get; set; }
    public decimal Price { get; set; }
}