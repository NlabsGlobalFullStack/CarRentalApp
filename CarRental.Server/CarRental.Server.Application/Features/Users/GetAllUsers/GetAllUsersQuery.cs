using MediatR;

namespace CarRental.Server.Application.Features.Users.GetAllUsers;
public sealed record GetAllUsersQuery : IRequest<List<UserResponse>>;
