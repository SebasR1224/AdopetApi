using System.Text.RegularExpressions;

namespace Domain.Common.ValueObjects;

public partial record PhoneNumber
{
    private const int DefaultLength = 9;
    private const string Pattern = @"^(?:-*\d-*){8}$";

    private PhoneNumber(string value) => Value = value;

    public string Value { get; init; }

    public static PhoneNumber? Create(string value)
    {
        if (string.IsNullOrEmpty(value) || value.Length != DefaultLength || !PhoneNumberRegex().IsMatch(value))
            return null;

        return new PhoneNumber(value);
    }

    [GeneratedRegex(Pattern)]
    private static partial Regex PhoneNumberRegex();
}