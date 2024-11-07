using Domain.Primitives;

namespace Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    public double Value { get; }

    private Rating(double value)
    {
        Value = value;
    }

    public static Rating? Create(double value)
    {
        if (value < 0 || value > 5)
            return null;

        return new Rating(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
