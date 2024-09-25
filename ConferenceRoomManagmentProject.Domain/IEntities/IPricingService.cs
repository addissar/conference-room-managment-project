using ConferenceRoomManagmentProject.Domain.Entities;

namespace ConferenceRoomManagmentProject.Domain.IEntities;

public interface IPricingService
{
    decimal CalculateBookingCost(Room room, DateTime startTime, DateTime endTime, List<Service> services);
}