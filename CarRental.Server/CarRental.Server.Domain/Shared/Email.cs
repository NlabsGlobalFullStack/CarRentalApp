using System.Text.RegularExpressions;

namespace CarRental.Server.Domain.Shared;

public sealed record Email
{
    public string Value { get; set; }

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Name cannot be empty!");
        }

        if (value.Length < 5)
        {
            throw new ArgumentException("Name cannot be less than 5 characters!");
        }

        if (value.Length > 80)
        {
            throw new ArgumentException("The name cannot be more than 80 characters!");
        }

        var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if (!Regex.IsMatch(value, emailRegex))
        {
            throw new ArgumentException("Invalid email format!");
        }

        var email = new Email(value);

        return email;
    }
}