using Domain.Primitives;

namespace Domain.Users;

public sealed class UserId : ValueObject
{
    public Guid Value { get; }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId Create(Guid value) => new UserId(value);

    public static UserId CreateUnique() => new UserId(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}