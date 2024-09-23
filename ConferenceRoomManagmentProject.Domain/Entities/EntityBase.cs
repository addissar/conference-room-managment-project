namespace ConferenceRoomManagmentProject.Domain.Entities;

public abstract class EntityBase
{
    public Guid Id { get; set; }

    protected EntityBase()
    {
        Id = Guid.NewGuid(); // Automatically generate a GUID for new entities
    }
}