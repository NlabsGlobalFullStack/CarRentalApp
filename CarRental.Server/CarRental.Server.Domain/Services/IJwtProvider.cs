using CarRental.Server.Domain.Dtos;
using CarRental.Server.Domain.Users;

namespace CarRental.Server.Domain.Services;
public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateTokenAsync(AppUser user, bool rememberMe);
}