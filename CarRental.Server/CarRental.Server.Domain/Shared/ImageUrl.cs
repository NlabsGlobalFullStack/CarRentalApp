namespace CarRental.Server.Domain.Shared;

public sealed record ImageUrl
{
    public string Value { get; set; } = default!;

    public ImageUrl(string value)
    {
        Value = value;
    }

    public static ImageUrl Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Image cannot be empty!");
        }

        var imageUrl = new ImageUrl(value);

        return imageUrl;
    }
}
