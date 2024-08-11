using CarRental.Server.Domain.Abstractions;
using CarRental.Server.Domain.Shared;

namespace CarRental.Server.Domain.Brands;
public sealed class Brand : Entity
{
    public Name Name { get; set; } = default!;
    public Model Model { get; set; } = default!;
}


public sealed record Model
{
    public Model(short value)
    {
        Value = value;
    }

    public short Value { get; set; }

    public bool IsTrue()
    {
        return Value >= 1900 && Value <= 9999;
    }
}