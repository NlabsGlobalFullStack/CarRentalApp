namespace CarRental.Server.Domain.Shared;

public sealed record Description
{
    public string Value { get; set; }
    public Description(string value)
    {
        Value = value;
    }

    public static Description Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Description must be at least 10 characters!");
        }

        if (value.Length < 10)
        {
            throw new ArgumentException("Description must be at least 10 characters!");
        }

        if (value.Length > 1500)
        {
            throw new ArgumentException("Description must be 1500 characters maximum!");
        }

        var description = new Description(value);

        return description;
    }

}
