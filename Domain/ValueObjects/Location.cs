namespace Domain.ValueObjects;

// описание локации (одно из полей/характеристик топика)
public record Location
{
    public string City { get; } = default!;
    public string Street { get; } = default!;

    private Location(string city, string street)
    {
        City = city;
        Street = street;
    }

    // фабрика для создания
    public static Location Of(string city, string street)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(city); // готовые исключения
        ArgumentException.ThrowIfNullOrWhiteSpace(street);

        return new Location(city, street);
    }
}