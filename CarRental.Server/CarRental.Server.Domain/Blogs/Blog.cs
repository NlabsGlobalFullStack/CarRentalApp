using CarRental.Server.Domain.Abstractions;
using CarRental.Server.Domain.Shared;
using CarRental.Server.Domain.Users;

namespace CarRental.Server.Domain.Blogs;
public sealed class Blog : Entity
{
    public Name Title { get; private set; } = default!;
    public Identity AuthorId { get; private set; } = default!;
    public AppUser? User { get; private set; }
    public Identity BlogCategoryId { get; private set; } = default!;
    public BlogCategory? BlogCategory { get; private set; }
    public ImageUrl CoverImageUrl { get; private set; } = default!;
    public Description Description { get; private set; } = default!;
    public TagCloud TagClouds { get; private set; } = default!;
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public List<Comment>? Comments { get; set; }
}
