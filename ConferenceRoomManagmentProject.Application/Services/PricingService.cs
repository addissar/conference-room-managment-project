using ConferenceRoomManagmentProject.Domain.Entities;
using ConferenceRoomManagmentProject.Domain.IEntities;

namespace ConferenceRoomManagmentProject.Application.Services;

public class PricingService : IPricingService
{
    public decimal CalculateBookingCost(Room room, DateTime startTime, DateTime endTime, List<Service> services)
    {
        decimal totalCost = 0;
        // DateTime endTime = startTime.Add(duration);
        decimal basePricePerHour = (decimal)room.BaseHourlyRate;
        //TODO add to DB timezones and adjustments  
        var timeZones = new List<(TimeSpan Start, TimeSpan End, decimal Adjustment)>
        {
            (new TimeSpan(6, 0, 0), new TimeSpan(9, 0, 0), 0.90m),  // Morning discount 10%
            (new TimeSpan(9, 0, 0), new TimeSpan(18, 0, 0), 1.00m), // Standard price
            (new TimeSpan(12, 0, 0), new TimeSpan(14, 0, 0), 1.15m),// Peak surcharge 15%
            (new TimeSpan(18, 0, 0), new TimeSpan(23, 0, 0), 0.80m) // Evening discount 20%
        };

        foreach (var zone in timeZones)
        {
            TimeSpan overlapDuration = GetOverlap(startTime, endTime, zone.Start, zone.End);

            if (overlapDuration > TimeSpan.Zero)
            {
                decimal subPeriodCost = basePricePerHour * (decimal)overlapDuration.TotalHours * zone.Adjustment;
                totalCost += subPeriodCost;
            }
        }

        // Add additional service costs
        decimal serviceCost = services.Sum(s => s.Price);
        return totalCost + serviceCost;
    }

    private TimeSpan GetOverlap(DateTime startTime, DateTime endTime, TimeSpan zoneStart, TimeSpan zoneEnd)
    {
        var bookingStart = startTime.TimeOfDay;
        var bookingEnd = endTime.TimeOfDay;

        TimeSpan overlapStart = (bookingStart > zoneStart) ? bookingStart : zoneStart;
        TimeSpan overlapEnd = (bookingEnd < zoneEnd) ? bookingEnd : zoneEnd;

        return (overlapStart < overlapEnd) ? overlapEnd - overlapStart : TimeSpan.Zero;
    }
}