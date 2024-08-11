using CarRental.Server.Domain.Abstractions;
using CarRental.Server.Domain.Cars;
using CarRental.Server.Domain.Dtos;
using CarRental.Server.Domain.Shared;

namespace CarRental.Server.Domain.Reservations;
public sealed class Reservation : Entity
{
    public Name FirstName { get; private set; } = default!;
    public Name LastName { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Phone Phone { get; private set; } = default!;
    public string CarId { get; private set; } = default!;
    public Car? Car { get; set; }

    public void Create(CreateReservationDto request)
    {
        FirstName = Name.Create(request.FirstName);
        LastName = Name.Create(request.LastName);
        Email = Email.Create(request.Email);
        Phone = Phone.Create(request.Phone);

        var control = Email.Create(request.Email);

        if (IsEmailRegistered(control.Value))
        {
            throw new InvalidOperationException("This email is already registered.");
        }
    }

    private bool IsEmailRegistered(string email)
    {
        // Bu yöntem, email'in halihazırda kayıtlı olup olmadığını kontrol etmek için kullanılacak
        // Veritabanı ya da başka bir kaynak üzerinde email kontrolü yapılabilir.
        // Bu örnekte basit bir kontrol olarak false döndürülüyor.
        return false;
    }
}
