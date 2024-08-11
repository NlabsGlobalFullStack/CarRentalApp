using CarRental.Server.Domain.Shared;

namespace CarRental.Server.Domain.Users;
public sealed class UserRole
{
    public UserRole()
    {
        UserId = new Identity(Guid.NewGuid().ToString());
        RoleId = new Identity(Guid.NewGuid().ToString());
    }

    public Identity UserId { get; set; } = default!;
    public Identity RoleId { get; set; } = default!;
}
