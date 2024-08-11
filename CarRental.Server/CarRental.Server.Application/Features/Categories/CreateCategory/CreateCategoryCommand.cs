using MediatR;
using Nlabs.Result;

namespace CarRental.Server.Application.Features.Categories.CreateCategory;
public sealed record CreateCategoryCommand(string Name) : IRequest<Result<string>>;
