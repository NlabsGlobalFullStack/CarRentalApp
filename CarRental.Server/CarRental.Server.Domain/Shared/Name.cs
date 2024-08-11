namespace CarRental.Server.Domain.Shared;
public sealed record Name
{
    private Name(string value)
    {
        Value = value;
    }

    public string Value { get; set; } = default!;

    public static Name Create(string value)
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

        var name = new Name(value);

        return name;
    }
}
