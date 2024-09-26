namespace ConferenceRoomManagmentProject.Application.DTO;

public class BookingDTO
{
    public Guid RoomId { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public List<ServiceDTO> Services { get; set; }
}