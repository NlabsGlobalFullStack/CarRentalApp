namespace CarRental.Server.Domain.Dtos.Blog;

public sealed record CreateBlogDto(
    string Name,
    string AuthorId,
    string BlogCategoryId,
    string ImageUrl,
    string Description,
    string TagClouds
);
