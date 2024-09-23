using ConferenceRoomManagmentProject.Domain.Entities;
namespace ConferenceRoomManagmentProject.Domain.IRepository;

public interface IBookingRepository
{
    Task<Booking> GetBookingByIdAsync(Guid id);
    Task<IEnumerable<Booking>> GetBookingsForRoomAsync(Guid roomId, DateTime startTime, DateTime endTime);
    Task<Booking> AddBookingAsync(Booking booking);
    Task UpdateBookingAsync(Booking booking);
    Task DeleteBookingAsync(Guid id);
}