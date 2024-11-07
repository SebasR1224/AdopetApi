using Domain.Primitives;

namespace Domain.Animals.ValueObjects;

public sealed class AnimalId : ValueObject
{
    public Guid Value { get; }

    private AnimalId(Guid value)
    {
        Value = value;
    }

    public static AnimalId CreateUnique()
    {
        return new AnimalId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}