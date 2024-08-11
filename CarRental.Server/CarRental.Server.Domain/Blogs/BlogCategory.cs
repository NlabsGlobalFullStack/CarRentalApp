using CarRental.Server.Domain.Abstractions;
using CarRental.Server.Domain.Shared;

namespace CarRental.Server.Domain.Blogs;

public sealed class BlogCategory : Entity
{
    public Name Name { get; set; } = default!;
    public List<Blog>? Blogs { get; set; }
}
