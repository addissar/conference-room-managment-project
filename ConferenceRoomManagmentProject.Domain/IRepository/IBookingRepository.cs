using ConferenceRoomManagmentProject.Domain.Entities;
namespace ConferenceRoomManagmentProject.Domain.IRepository;

public interface IBookingRepository
{
    Task<Booking> GetBookingByIdAsync(int id);
    Task<IEnumerable<Booking>> GetBookingsForRoomAsync(int roomId, DateTime startTime, DateTime endTime);
    Task<Booking> AddBookingAsync(Booking booking);
    Task UpdateBookingAsync(Booking booking);
    Task DeleteBookingAsync(int id);
}