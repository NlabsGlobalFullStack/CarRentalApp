namespace CarRental.Server.Domain.Dtos.Blog;

public sealed record UpdateBlogDto(
    string Id,
    string Name,
    string AuthorId,
    string BlogCategoryId,
    string ImageUrl,
    string Description,
    string TagClouds
);
