namespace CarRental.Server.Domain.Cars;

public sealed record Plate
{
    public Plate(string value)
    {
        Value = value;
    }
    public string Value { get; set; } = default!;

    public static Plate Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Plate cannot be empty!");
        }

        if (value.Length < 5)
        {
            throw new ArgumentException("Plate cannot be less than 5 characters!");
        }

        if (value.Length > 15)
        {
            throw new ArgumentException("The plate cannot be more than 15 characters!");
        }

        var plate = new Plate(value);

        return plate;
    }
}
