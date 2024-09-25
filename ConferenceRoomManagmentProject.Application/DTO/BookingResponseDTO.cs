namespace ConferenceRoomManagmentProject.Application.DTO;

public class BookingResponseDTO
{
    public Guid BookingId { get; set; }
    public Guid RoomId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public List<ServiceDTO> Services { get; set; }
    
    
}