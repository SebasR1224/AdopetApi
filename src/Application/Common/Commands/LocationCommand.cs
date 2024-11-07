namespace Application.Common.Commands;

public record LocationCommand(
    double Latitude,
    double Longitude,
    string Address,
    string City,
    string PostalCode
);
