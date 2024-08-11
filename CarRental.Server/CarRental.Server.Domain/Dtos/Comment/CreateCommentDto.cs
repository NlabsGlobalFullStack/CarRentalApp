namespace CarRental.Server.Domain.Dtos.Comment;

public sealed record CreateCommentDto(
    string Name,
    string BlogId,
    string Description,
    string Email);