using CarRental.Server.Domain.Abstractions;
using CarRental.Server.Domain.Shared;

namespace CarRental.Server.Domain.Cars;
public sealed class Category : Entity
{
    public Name Name { get; set; } = default!;
}
