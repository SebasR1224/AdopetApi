using Domain.Primitives;

namespace Domain.Abandonments.ValueObjects;

public sealed class ReportAbandonmentImageId : ValueObject
{
    public Guid Value { get; }

    private ReportAbandonmentImageId(Guid value)
    {
        Value = value;
    }

    public static ReportAbandonmentImageId Create(Guid value)
    {
        return new ReportAbandonmentImageId(value);
    }
    public static ReportAbandonmentImageId CreateUnique()
    {
        return new ReportAbandonmentImageId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}