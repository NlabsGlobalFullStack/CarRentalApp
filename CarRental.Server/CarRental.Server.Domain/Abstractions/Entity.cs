using CarRental.Server.Domain.Shared;

namespace CarRental.Server.Domain.Abstractions;
public abstract class Entity
{
    protected Entity()
    {
        Id = new Identity(Guid.NewGuid().ToString());
    }
    public Identity Id { get; set; }
}