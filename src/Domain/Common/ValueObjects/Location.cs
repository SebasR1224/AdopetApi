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

    public double CalculateDistance(Location otherLocation)
    {
        const double EarthRadiusKm = 6371.0;

        double dLat = DegreesToRadians(otherLocation.Latitude - Latitude);
        double dLon = DegreesToRadians(otherLocation.Longitude - Longitude);

        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(DegreesToRadians(Latitude)) * Math.Cos(DegreesToRadians(otherLocation.Latitude)) *
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        return EarthRadiusKm * c;
    }

    private static double DegreesToRadians(double degrees)
    {
        return degrees * Math.PI / 180.0;
    }

#pragma warning disable CS8618
    private Location() { }
#pragma warning restore CS8618
}