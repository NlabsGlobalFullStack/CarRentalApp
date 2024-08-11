namespace CarRental.Server.Domain.Shared;

public sealed record Phone
{
    private Phone(string value)
    {
        Value = value;
    }

    public string Value { get; set; } = default!;

    public static Phone Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Phone cannot be empty!");
        }

        if (value.Length != 13)
        {
            throw new ArgumentException("Phone cannot be less than 13 characters!");
        }

        var phone = new Phone(value);

        return phone;
    }
}
