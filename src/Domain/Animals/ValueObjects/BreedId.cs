using Domain.Primitives;

namespace Domain.Animals.ValueObjects;

public sealed class BreedId : ValueObject
{
    public Guid Value { get; }

    private BreedId(Guid value)
    {
        Value = value;
    }

    public static BreedId CreateUnique()
    {
        return new BreedId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}