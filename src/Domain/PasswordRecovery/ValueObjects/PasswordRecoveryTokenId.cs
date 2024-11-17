using Domain.Primitives;

namespace Domain.PasswordRecovery.ValueObjects;

public sealed class PasswordRecoveryTokenId : ValueObject
{
    public Guid Value { get; }

    private PasswordRecoveryTokenId(Guid value)
    {
        Value = value;
    }

    public static PasswordRecoveryTokenId Create(Guid value) => new PasswordRecoveryTokenId(value);

    public static PasswordRecoveryTokenId CreateUnique() => new PasswordRecoveryTokenId(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}