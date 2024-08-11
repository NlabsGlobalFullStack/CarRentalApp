using CarRental.Server.Domain.Abstractions;
using CarRental.Server.Domain.Shared;

namespace CarRental.Server.Domain.Users;
public sealed class Setting : Entity
{
    public Name Image { get; set; } = default!;
    public Email Email { get; set; } = default!;
}
