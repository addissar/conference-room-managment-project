namespace ConferenceRoomManagmentProject.Domain.IEntities;

public interface IRoom
{
    string Name { get; set; }
    int? Capacity { get; set; }
    decimal? BaseHourlyRate { get; set; }
}