using CarRental.Server.Domain.Cars;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Server.Application.Features.Categories.GetAll;
internal sealed class GetAllCategoriesQueryHandler
    (
        ICategoryRepository categoryRepository
    ) : IRequestHandler<GetAllCategoriesQuery, List<CategoryResponse>>
{
    public async Task<List<CategoryResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetAll().ToListAsync(cancellationToken);

        var response = categories.Select(s => new CategoryResponse
        {
            Id = s.Id.Value,
            Name = s.Name.Value,
        }).ToList();

        return response;
    }
}
