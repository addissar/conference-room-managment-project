using ConferenceRoomManagmentProject.Domain.Entities;

namespace ConferenceRoomManagmentProject.Domain.IEntities;

public interface IBookingService
{
    Guid  BookingId { get; set; }
    Guid  ServiceId { get; set; }
    Booking Booking { get; set; }
    Service Service { get; set; }
    decimal Price { get; set; }
}