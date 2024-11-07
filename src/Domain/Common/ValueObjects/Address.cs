namespace Domain.Common.ValueObjects;

public partial record Address
{
    private Address(string country, string city, string line1, string line2, string state, string postalCode)
    {
        Country = country;
        City = city;
        Line1 = line1;
        Line2 = line2;
        State = state;
        PostalCode = postalCode;
    }

    public string Country { get; init; }
    public string City { get; init; }
    public string Line1 { get; init; }
    public string Line2 { get; init; }
    public string State { get; init; }
    public string PostalCode { get; init; }

    public static Address? Create(string country, string city, string line1, string line2, string state, string postalCode)
    {
        if (string.IsNullOrEmpty(country) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(line1) || string.IsNullOrEmpty(line2) || string.IsNullOrEmpty(state) || string.IsNullOrEmpty(postalCode))
            return null;

        return new Address(country, city, line1, line2, state, postalCode);
    }

}