namespace Contracts.Common;

public record LocationRequest(
        double Latitude,
        double Longitude,
        string Address,
        string City,
        string PostalCode
    );