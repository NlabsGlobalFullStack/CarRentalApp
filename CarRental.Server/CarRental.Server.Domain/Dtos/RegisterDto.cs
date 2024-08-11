namespace CarRental.Server.Domain.Dtos;

public sealed record RegisterDto(
    string UserName,
    string Email,
    string FirstName,
    string LastName,
    string Password,
    string RePassword
);