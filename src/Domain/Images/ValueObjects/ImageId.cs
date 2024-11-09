using Domain.Primitives;

namespace Domain.Images.ValueObjects;

public sealed class ImageId : ValueObject
{
    public Guid Value { get; }

    private ImageId(Guid value)
    {
        Value = value;
    }

    public static ImageId Create(Guid value)
    {
        return new ImageId(value);
    }

    public static ImageId CreateUnique()
    {
        return new ImageId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
