namespace ConferenceRoomManagmentProject.Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public Room? Room { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public decimal TotalCost { get; set; }
    public List<BookingService> SelectedServices { get; set; } = new List<BookingService>();
}