using Domain.Primitives;

namespace Domain.Abandonments.ValueObjects;

public sealed class ReporterId : ValueObject
{
    public Guid Value { get; }

    private ReporterId(Guid value)
    {
        Value = value;
    }

    public static ReporterId Create(Guid value)
    {
        return new ReporterId(value);
    }
    public static ReporterId CreateUnique()
    {
        return new ReporterId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}