﻿using CarRental.Server.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Server.Application.Features.Users.GetAllUsers;
internal sealed class GetAllUsersQueryHandler
    (
        UserManager<AppUser> userManager
    ) : IRequestHandler<GetAllUsersQuery, List<UserResponse>>
{
    public async Task<List<UserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await userManager.Users.ToListAsync(cancellationToken);

        var response = users.Select(r => new UserResponse
        {
            Id = r.Id,
            FirstName = r.FirstName.Value,
            LastName = r.LastName.Value,
            FullName = r.FullName
        }).ToList();

        return response;
    }
}
