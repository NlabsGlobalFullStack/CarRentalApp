using CarRental.Server.Domain.Dtos;
using CarRental.Server.Domain.Services;
using CarRental.Server.Domain.Users;
using CarRental.Server.Infrastructure.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarRental.Server.Infrastructure.Services;
internal class JwtProvider(
    UserManager<AppUser> userManager,
    IOptions<JwtOptions> jwtOptions) : IJwtProvider
{
    public async Task<LoginCommandResponse> CreateTokenAsync(AppUser user, bool rememberMe)
    {
        List<Claim> claims = new()
        {
            new Claim("Id", user.Id.ToString()),
            new Claim("Name", user.FullName),
            new Claim("Email", user.Email ?? ""),
            new Claim("UserName", user.UserName ?? "")
        };

        DateTime expires = rememberMe ? DateTime.UtcNow.AddMonths(1) : DateTime.UtcNow.AddDays(1);


        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey));

        JwtSecurityToken jwtSecurityToken = new(
            issuer: jwtOptions.Value.Issuer,
            audience: jwtOptions.Value.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expires,
            signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512));

        JwtSecurityTokenHandler handler = new();

        var token = handler.WriteToken(jwtSecurityToken);

        var refreshToken = Guid.NewGuid().ToString();
        var refreshTokenExpires = expires.AddHours(1);

        user.UpdateRefreshToken(refreshToken);
        user.UpdateRefreshTokenExpires(refreshTokenExpires);

        await userManager.UpdateAsync(user);

        return new(token, refreshToken, refreshTokenExpires);
    }
}