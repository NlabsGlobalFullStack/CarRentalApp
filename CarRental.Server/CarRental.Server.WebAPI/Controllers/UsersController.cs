﻿using CarRental.Server.Application.Features.Users.GetAllUsers;
using CarRental.Server.WebAPI.Abstractions;
using CarRental.Server.WebAPI.AOP;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace CarRental.Server.WebAPI.Controllers;
public sealed class UsersController : ApiController
{
    public UsersController(IMediator mediator) : base(mediator) { }

    [AllowAnonymous]
    [EnableQueryWithMetadata]
    [HttpPost]
    public async Task<IActionResult> GetAll(ODataQueryOptions<UserResponse> queryOptions, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllUsersQuery(), cancellationToken);

        var queryResults = queryOptions.ApplyTo(response.AsQueryable());

        if (response.Count <= 0)
        {
            return BadRequest("List not found");
        }

        return Ok(response);
    }
}
