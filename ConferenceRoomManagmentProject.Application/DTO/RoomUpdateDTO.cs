namespace ConferenceRoomManagmentProject.Application.DTO;

public class RoomUpdateDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public decimal BasePricePerHour { get; set; }
    public List<ServiceDTO> Services { get; set; }
}