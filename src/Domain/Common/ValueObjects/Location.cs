using Domain.Primitives;

namespace Domain.Common.ValueObjects;

public sealed class Location : ValueObject
{
    public double Latitude { get; }
    public double Longitude { get; }
    public string Address { get; }
    public string City { get; }
    public string PostalCode { get; }

    private Location(double latitude, double longitude, string address, string city, string postalCode)
    {
        Latitude = latitude;
        Longitude = longitude;
        Address = address;
        City = city;
        PostalCode = postalCode;
    }

    public static Location? Create(double latitude, double longitude, string address, string city, string postalCode)
    {

        if (latitude < -90 || latitude > 90 ||
            longitude < -180 || longitude > 180 ||
            string.IsNullOrEmpty(address) ||
            string.IsNullOrEmpty(city) ||
            string.IsNullOrEmpty(postalCode))
        {
            return null;
        }
        return new Location(latitude, longitude, address, city, postalCode);
    }

    public override string ToString()
    {
        return $"{Address}, {City}, {PostalCode} (Lat: {Latitude}, Lon: {Longitude})";
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Latitude;
        yield return Longitude;
        yield return Address;
        yield return City;
        yield return PostalCode;
    }
}