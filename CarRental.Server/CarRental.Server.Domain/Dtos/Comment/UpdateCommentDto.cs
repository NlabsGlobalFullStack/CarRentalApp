namespace CarRental.Server.Domain.Dtos.Comment;

public sealed record UpdateCommentDto(
    string Id,
    string Name,
    string BlogId,
    string Description,
    string Email);