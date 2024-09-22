using ConferenceRoomManagmentProject.Domain.Entities;
namespace ConferenceRoomManagmentProject.Domain.IRepository;

public interface IBookingRepository
{
    Booking GetBookingById(int id);
    void AddBooking(Booking booking);
    IEnumerable<Booking> GetBookingsByRoomId(int roomId);
    void DeleteBooking(int id);
}