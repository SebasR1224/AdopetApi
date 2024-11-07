using Domain.Primitives;

namespace Domain.Foundations.ValueObjects;

public sealed class FoundationId : ValueObject
{
    public Guid Value { get; }

    private FoundationId(Guid value)
    {
        Value = value;
    }

    public static FoundationId Create(Guid value)
    {
        return new FoundationId(value);
    }

    public static FoundationId CreateUnique()
    {
        return new FoundationId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}