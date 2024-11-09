using Domain.Primitives;

namespace Domain.Files.ValueObjects;

public sealed class FileId : ValueObject
{
    public Guid Value { get; }

    private FileId(Guid value)
    {
        Value = value;
    }

    public static FileId Create(Guid value)
    {
        return new FileId(value);
    }

    public static FileId CreateUnique()
    {
        return new FileId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
