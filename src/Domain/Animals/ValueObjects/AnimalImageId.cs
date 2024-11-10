using Domain.Primitives;

namespace Domain.Animals.ValueObjects;

public sealed class AnimalImageId : ValueObject
{
    public Guid Value { get; }

    private AnimalImageId(Guid value)
    {
        Value = value;
    }

    public static AnimalImageId Create(Guid value)
    {
        return new AnimalImageId(value);
    }

    public static AnimalImageId CreateUnique()
    {
        return new AnimalImageId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}