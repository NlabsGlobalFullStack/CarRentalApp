﻿using CarRental.Server.Application.Features.Categories.CreateCategory;
using CarRental.Server.Application.Features.Categories.GetAll;
using CarRental.Server.WebAPI.Abstractions;
using CarRental.Server.WebAPI.AOP;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace CarRental.Server.WebAPI.Controllers;
[AllowAnonymous]
public sealed class CategoriesController : ApiController
{
    public CategoriesController(IMediator mediator) : base(mediator) { }

    [EnableQueryWithMetadata]
    [HttpPost]
    public async Task<IActionResult> GetAll(ODataQueryOptions<CategoryResponse> queryOptions, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllCategoriesQuery(), cancellationToken);

        var queryResults = queryOptions.ApplyTo(response.AsQueryable());

        if (response.Count <= 0)
        {
            return BadRequest("List not found");
        }

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}