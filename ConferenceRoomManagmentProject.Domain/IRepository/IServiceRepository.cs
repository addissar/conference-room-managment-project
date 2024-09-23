using ConferenceRoomManagmentProject.Domain.Entities;
namespace ConferenceRoomManagmentProject.Domain.IRepository;

public interface IServiceRepository
{
    Task<Service> GetServiceByIdAsync(Guid id);
    Task<IEnumerable<Service>> GetAllServicesAsync();
    Task<Service> AddServiceAsync(Service service);
    Task UpdateServiceAsync(Service service);
    Task DeleteServiceAsync(Guid id);
}