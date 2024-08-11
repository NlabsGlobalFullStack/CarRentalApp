namespace CarRental.Server.Application.Features.Categories.GetAll;

public sealed record CategoryResponse
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
}
