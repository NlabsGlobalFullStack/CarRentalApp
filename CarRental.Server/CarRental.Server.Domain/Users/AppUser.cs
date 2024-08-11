using CarRental.Server.Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Server.Domain.Users;
public sealed class AppUser : IdentityUser<string>
{
    public AppUser()
    {
        Id = Guid.NewGuid().ToString();
    }
    public Name FirstName { get; set; } = default!;
    public Name LastName { get; set; } = default!;
    public string FullName => string.Join(" ", FirstName, LastName);
    public string? RefreshToken { get; private set; }
    public DateTime? RefreshTokenExpires { get; private set; }

    public void UpdateRefreshToken(string refreshToken)
    {
        RefreshToken = refreshToken;
    }

    public void UpdateRefreshTokenExpires(DateTime refreshTokenExpires)
    {
        RefreshTokenExpires = refreshTokenExpires;
    }
}