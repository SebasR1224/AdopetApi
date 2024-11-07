using Domain.Primitives;

namespace Domain.Animals.ValueObjects;

public sealed class SpecieId : ValueObject
{
    public Guid Value { get; }

    private SpecieId(Guid value)
    {
        Value = value;
    }

    public static SpecieId CreateUnique()
    {
        return new SpecieId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}