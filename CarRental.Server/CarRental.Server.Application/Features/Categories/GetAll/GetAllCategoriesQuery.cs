using MediatR;

namespace CarRental.Server.Application.Features.Categories.GetAll;
public sealed record GetAllCategoriesQuery : IRequest<List<CategoryResponse>>;
