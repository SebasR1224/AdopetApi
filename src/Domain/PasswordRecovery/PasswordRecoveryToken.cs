using System.Reflection.Metadata;
using Domain.PasswordRecovery.ValueObjects;
using Domain.Primitives;

namespace Domain.PasswordRecovery;

public class PasswordRecoveryToken : AggregateRoot<PasswordRecoveryTokenId>
{
    private static readonly int _expirationHours = 24;
    public string Token { get; private set; }
    public string Email { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public bool IsUsed { get; private set; }

    private PasswordRecoveryToken(PasswordRecoveryTokenId id, string token, string email, DateTime expirationDate, bool isUsed) : base(id)
    {
        Token = token;
        Email = email;
        ExpirationDate = expirationDate;
        IsUsed = isUsed;
    }

    public static PasswordRecoveryToken Create(string email)
    {
        return new PasswordRecoveryToken(
            PasswordRecoveryTokenId.CreateUnique(),
            Guid.NewGuid().ToString("N"),
            email,
            DateTime.UtcNow.AddHours(_expirationHours),
            false
        );
    }

    public void MarkAsUsed()
    {
        IsUsed = true;
    }

    public bool IsValid()
    {
        return !IsUsed && DateTime.UtcNow <= ExpirationDate;
    }

#pragma warning disable CS8618
    private PasswordRecoveryToken() { }
#pragma warning restore CS8618
}