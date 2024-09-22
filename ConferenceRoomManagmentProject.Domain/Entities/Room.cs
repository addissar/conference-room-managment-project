namespace ConferenceRoomManagmentProject.Domain.Entities;

public class Room
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? Capacity { get; set; }
    public decimal? BaseHourlyRate { get; set; }
    public List<RoomService> AvailableServices { get; set; } = new List<RoomService>();
}