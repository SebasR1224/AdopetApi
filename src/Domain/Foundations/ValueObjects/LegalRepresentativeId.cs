using Domain.Primitives;

namespace Domain.Foundations.ValueObjects;

public sealed class LegalRepresentativeId : ValueObject
{
    public Guid Value { get; }

    private LegalRepresentativeId(Guid value)
    {
        Value = value;
    }

    public static LegalRepresentativeId Create(Guid value)
    {
        return new LegalRepresentativeId(value);
    }

    public static LegalRepresentativeId CreateUnique()
    {
        return new LegalRepresentativeId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}