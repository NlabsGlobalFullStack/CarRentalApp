namespace CarRental.Server.Domain.Dtos;
public sealed record CreateReservationDto(
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string Test
);