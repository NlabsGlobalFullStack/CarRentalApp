using CarRental.Server.Domain.Abstractions;
using CarRental.Server.Domain.Shared;

namespace CarRental.Server.Domain.Cars;
public sealed class Car : Entity
{
    public Identity CategoryId { get; set; } = default!;
    public Category? Category { get; set; }
    public Plate Plate { get; set; } = default!;
    public Color Color { get; set; } = default!;
}
