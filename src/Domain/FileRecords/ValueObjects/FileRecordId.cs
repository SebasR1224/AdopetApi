using Domain.Primitives;

namespace Domain.FileRecords.ValueObjects;

public sealed class FileRecordId : ValueObject
{
    public Guid Value { get; }

    private FileRecordId(Guid value)
    {
        Value = value;
    }

    public static FileRecordId Create(Guid value)
    {
        return new FileRecordId(value);
    }

    public static FileRecordId CreateUnique()
    {
        return new FileRecordId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}