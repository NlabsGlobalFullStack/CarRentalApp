using CarRental.Server.Domain.Dtos;
using CarRental.Server.Domain.Services;
using CarRental.Server.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nlabs.Result;

namespace CarRental.Server.Application.Features.Auth.Login;
internal sealed class LoginCommandHandler(
    UserManager<AppUser> userManager,
    SignInManager<AppUser> signInManager,
    IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
{
    public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.Users
            .FirstOrDefaultAsync(p =>
            p.UserName == request.UserNameOrEmail ||
            p.Email == request.UserNameOrEmail,
            cancellationToken);

        if (user is null)
        {
            return (500, "User not found!");
        }

        SignInResult signInResult = await signInManager.CheckPasswordSignInAsync(user, request.Password, true);

        if (signInResult.IsLockedOut)
        {
            TimeSpan? timeSpan = user.LockoutEnd - DateTime.UtcNow;
            if (timeSpan is not null)
                return (500, $"User has been blocked for {Math.Ceiling(timeSpan.Value.TotalMinutes)} minutes because you entered your password incorrectly 3 times.!");
            else
                return (500, "Your user has been blocked for 5 minutes because they entered the wrong password 3 times!");
        }

        if (signInResult.IsNotAllowed)
        {
            return (500, "Your email address is not confirmed!");
        }

        if (!signInResult.Succeeded)
        {
            return (500, "Your password is incorrect!");
        }

        var loginResponse = await jwtProvider.CreateTokenAsync(user, request.RememberMe);


        return loginResponse;
    }
}