using Domain.Primitives;

namespace Domain.Abandonments.ValueObjects;

public sealed class ReportAbandonmentId : ValueObject
{
    public Guid Value { get; }

    private ReportAbandonmentId(Guid value)
    {
        Value = value;
    }

    public static ReportAbandonmentId CreateUnique()
    {
        return new ReportAbandonmentId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}