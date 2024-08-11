using CarRental.Server.Domain.Dtos;
using MediatR;
using Nlabs.Result;

namespace CarRental.Server.Application.Features.Auth.Login;
public sealed record LoginCommand(
    string UserNameOrEmail,
    string Password,
    bool RememberMe) : IRequest<Result<LoginCommandResponse>>;