namespace CarRental.Server.Domain.Dtos.Comment;

public sealed record ListCommentDto
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string BlogId { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime CreatedDate { get; set; } = default!;
}
