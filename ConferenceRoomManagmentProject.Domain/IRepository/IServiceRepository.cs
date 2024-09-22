using ConferenceRoomManagmentProject.Domain.Entities;
namespace ConferenceRoomManagmentProject.Domain.IRepository;

public interface IServiceRepository
{
    IEnumerable<Service> GetAllServices();
    Service GetServiceById(int id);
}