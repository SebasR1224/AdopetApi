using Domain.Primitives;

namespace Domain.Reporters.ValueObjects;

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

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}